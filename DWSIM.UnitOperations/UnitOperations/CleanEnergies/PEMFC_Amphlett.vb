﻿Imports System.IO
Imports DWSIM.UnitOperations.UnitOperations
Imports Python.Runtime

Namespace UnitOperations

    Public Class PEMFC_Amphlett

        Inherits PEMFuelCellUnitOpBase

        Public Overrides Property Prefix As String = "FCA-"

        Public Overrides Function GetDisplayName() As String
            Return "PEM Fuel Cell (Amphlett)"
        End Function

        Public Overrides Function GetDisplayDescription() As String
            Return "PEM Fuel Cell (OPEM Amphlett Static Model)"
        End Function

        Public Sub New()

            MyBase.New()

            InputParameters.Clear()
            InputParameters.Add("i-start", New Auxiliary.PEMFuelCellModelParameter("i-start", "Cell operating current start point", 0, "A"))
            InputParameters.Add("i-stop", New Auxiliary.PEMFuelCellModelParameter("i-stop", "Cell operating current end point", 75, "A"))
            InputParameters.Add("i-step", New Auxiliary.PEMFuelCellModelParameter("i-step", "Cell operating current", 0.1, "A"))
            InputParameters.Add("A", New Auxiliary.PEMFuelCellModelParameter("A", "Active area", 50.6, "cm2"))
            InputParameters.Add("l", New Auxiliary.PEMFuelCellModelParameter("l", "Membrane thickness", 0.0178, "cm"))
            InputParameters.Add("lambda", New Auxiliary.PEMFuelCellModelParameter("lambda", "Adjustable parameter (14-23)", 23, ""))
            InputParameters.Add("R", New Auxiliary.PEMFuelCellModelParameter("R", "R-Electronic", 0, "ohm"))
            InputParameters.Add("JMax", New Auxiliary.PEMFuelCellModelParameter("JMax", "Maximum current density", 1.5, "A/cm2"))
            InputParameters.Add("N", New Auxiliary.PEMFuelCellModelParameter("N", "Number of single cells", 1, ""))

        End Sub

        Public Overrides Sub PopulateEditorPanel(ctner As Object)

        End Sub

        Public Overrides Sub DisplayEditForm()

        End Sub

        Public Overrides Sub UpdateEditForm()

        End Sub

        Public Overrides Sub CloseEditForm()

        End Sub

        Public Overrides Function ReturnInstance(typename As String) As Object

            Return New PEMFC_Amphlett

        End Function

        Public Overrides Function GetIconBitmap() As Object

            Return My.Resources.fuel_cell

        End Function

        Public Overrides Function CloneXML() As Object

            Dim obj As ICustomXMLSerialization = New PEMFC_Amphlett()
            obj.LoadData(Me.SaveData)
            Return obj

        End Function

        Public Overrides Function CloneJSON() As Object

            Throw New NotImplementedException()

        End Function

        Public Overrides Sub Calculate(Optional args As Object = Nothing)

            DWSIM.GlobalSettings.Settings.ShutdownPythonEnvironment()

            DWSIM.GlobalSettings.Settings.InitializePythonEnvironment(OPEMPath)

            Dim msin = GetInletMaterialStream(0)
            Dim msout = GetOutletMaterialStream(0)

            Dim esout = GetOutletEnergyStream(1)

            Dim names = msin.Phases(0).Compounds.Keys.ToList()

            If Not names.Contains("Water") Then Throw New Exception("Needs Water compound")
            If Not names.Contains("Hydrogen") Then Throw New Exception("Needs Hydrogen compound")
            If Not names.Contains("Oxygen") Then Throw New Exception("Needs Oxygen compound")

            Dim Pin = msin.GetPressure()

            Dim T = msin.GetTemperature()

            Dim PH2 = msin.Phases(2).Compounds("Hydrogen").MoleFraction.GetValueOrDefault() * Pin / 101325.0
            Dim PO2 = msin.Phases(2).Compounds("Oxygen").MoleFraction.GetValueOrDefault() * Pin / 101325.0

            Dim results As Object = Nothing

            Using Py.GIL

                Dim opem As Object = Py.Import("opem.Static.Amphlett")

                Dim parameters As New PyDict()
                parameters("T") = T.ToPython()
                parameters("PH2") = PH2.ToPython()
                parameters("PO2") = PO2.ToPython()
                parameters("i-start") = InputParameters("i-start").Value.ToPython()
                parameters("i-step") = InputParameters("i-step").Value.ToPython()
                parameters("i-stop") = InputParameters("i-stop").Value.ToPython()
                parameters("A") = InputParameters("A").Value.ToPython()
                parameters("l") = InputParameters("l").Value.ToPython()
                parameters("lambda") = InputParameters("lambda").Value.ToPython()
                parameters("N") = InputParameters("N").Value.ToPython()
                parameters("R") = InputParameters("R").Value.ToPython()
                parameters("JMax") = InputParameters("JMax").Value.ToPython()
                parameters("Name") = "Amphlett_Test".ToPython()

                results = opem.Static_Analysis(InputMethod:=parameters.ToPython(), TestMode:=True.ToPython(), PrintMode:=False.ToPython(), ReportMode:=False.ToPython())

                If results Is Nothing OrElse results("Status").ToString() = "False" Then
                    Throw New Exception("Calculation error")
                End If

            End Using

            Dim P = ToList(results("P"))
            Dim I = ToList(results("I"))
            Dim V = ToList(results("V"))
            Dim EFF = ToList(results("EFF"))
            Dim Ph = ToList(results("Ph"))
            Dim V0 = ToList(results("V0"))
            Dim K = ToList(results("K"))
            Dim VE = ToList(results("VE"))
            Dim Eta_Active = ToList(results("Eta_Active"))
            Dim Eta_Ohmic = ToList(results("Eta_Ohmic"))
            Dim Eta_Conc = ToList(results("Eta_Conc"))

            'I: 74.9
            'Enernst: 1.19075 V
            'Eta Activation :  0.5564162618842647 V
            'Eta Concentration :  0.06401178884389878 V
            'Eta Ohmic :  0.20564684562177526 V
            'Loss: 0.8260748963499388 V
            'PEM Efficiency :  0.23376609208337254 
            'Power: 27.314165263389583 W
            'Power-Stack :  27.314165263389583 W
            'Power-Thermal :  64.81283473661043 W
            'VStack: 0.36467510365006117 V
            'Vcell: 0.36467510365006117 V

            OutputParameters.Clear()
            OutputParameters.Add("I", New Auxiliary.PEMFuelCellModelParameter("I", "Cell Operating Current", I.Last(), "A"))
            OutputParameters.Add("P", New Auxiliary.PEMFuelCellModelParameter("P", "Power", P.Last(), "W"))
            OutputParameters.Last.Value.ValuesX = I
            OutputParameters.Last.Value.ValuesY = P
            OutputParameters.Last.Value.TitleX = "Current"
            OutputParameters.Last.Value.TitleY = "Power"
            OutputParameters.Last.Value.UnitsX = "A"
            OutputParameters.Last.Value.UnitsY = "W"
            OutputParameters.Add("Ph", New Auxiliary.PEMFuelCellModelParameter("Ph", "Thermal Power", Ph.Last(), "W"))
            OutputParameters.Last.Value.ValuesX = I
            OutputParameters.Last.Value.ValuesY = Ph
            OutputParameters.Last.Value.TitleX = "Current"
            OutputParameters.Last.Value.TitleY = "Thermal Power"
            OutputParameters.Last.Value.UnitsX = "A"
            OutputParameters.Last.Value.UnitsY = "W"
            OutputParameters.Add("EFF", New Auxiliary.PEMFuelCellModelParameter("EFF", "Efficiency", EFF.Last(), ""))
            OutputParameters.Last.Value.ValuesX = I
            OutputParameters.Last.Value.ValuesY = EFF
            OutputParameters.Last.Value.TitleX = "Current"
            OutputParameters.Last.Value.TitleY = "Efficiency"
            OutputParameters.Last.Value.UnitsX = "A"
            OutputParameters.Last.Value.UnitsY = ""
            OutputParameters.Add("V", New Auxiliary.PEMFuelCellModelParameter("V", "FC Voltage", V.Last(), "V"))
            OutputParameters.Last.Value.ValuesX = I
            OutputParameters.Last.Value.ValuesY = V
            OutputParameters.Last.Value.TitleX = "Current"
            OutputParameters.Last.Value.TitleY = "FC Voltage"
            OutputParameters.Last.Value.UnitsX = "A"
            OutputParameters.Last.Value.UnitsY = "V"
            OutputParameters.Add("VE", New Auxiliary.PEMFuelCellModelParameter("VE", "Estimated FC Voltage", VE.Last(), "V"))
            OutputParameters.Last.Value.ValuesX = I
            OutputParameters.Last.Value.ValuesY = VE
            OutputParameters.Last.Value.TitleX = "Current"
            OutputParameters.Last.Value.TitleY = "Estimated FC Voltage"
            OutputParameters.Last.Value.UnitsX = "A"
            OutputParameters.Last.Value.UnitsY = "V"

            Dim Current = I.Last()

            Dim WasteHeat = Ph.Last() / 1000.0 'kW

            Dim ElectronTransfer = Current / 96485.3365 * InputParameters("N").Value 'mol/s

            Dim waterr = ElectronTransfer / 4 * 2 'mol/s
            Dim h2r = ElectronTransfer / 4 * 2 'mol/s
            Dim o2r = ElectronTransfer / 4 'mol/s

            Dim N0 = msin.Phases(0).Compounds.Values.Select(Function(c) c.MolarFlow.GetValueOrDefault()).ToList()

            Dim Nf = New List(Of Double)(N0)

            For j As Integer = 0 To N0.Count - 1
                If names(j) = "Water" Then
                    Nf(j) = N0(j) + waterr
                ElseIf names(j) = "Hydrogen" Then
                    Nf(j) = N0(j) - h2r
                ElseIf names(j) = "Oxygen" Then
                    Nf(j) = N0(j) - o2r
                End If
            Next

            msout.Clear()
            msout.ClearAllProps()

            msout.SetOverallComposition(Nf.ToArray().MultiplyConstY(1.0 / Nf.Sum))
            msout.SetMolarFlow(Nf.Sum)
            msout.SetPressure(msin.GetPressure)
            msout.SetMassEnthalpy(msin.GetMassEnthalpy() + WasteHeat / msin.GetMassFlow())
            msout.SetFlashSpec("PH")

            msout.AtEquilibrium = False

        End Sub

    End Class

End Namespace