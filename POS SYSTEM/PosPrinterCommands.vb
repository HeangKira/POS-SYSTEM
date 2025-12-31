' PosPrinterCommands.vb (New Module File)
Imports System.Runtime.InteropServices
Imports System.Text

Module PosPrinterCommands

    ' --- WIN32 API DECLARATIONS FOR RAW PRINTING ---

    ' Define required unmanaged data structure
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Private Structure DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)> Public pDataType As String
    End Structure

    ' Function declarations
    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function OpenPrinter(ByVal pPrinterName As String, ByRef phPrinter As IntPtr, ByVal pDefault As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal Level As Integer, ByRef pDocInfo As DOCINFOA) As Integer
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Private Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBuf As Byte(), ByVal cbBuf As Integer, ByRef pcWritten As Integer) As Boolean
    End Function

    ' --- ESC/POS CASH DRAWER COMMAND ---

    ' The standard ESC/POS command to kick the drawer: ESC p m t1 t2
    ' ESC = 27 (or &H1B)
    ' p   = 112 (or &H70)
    ' m   = 0x30 or 0x31 (Port 1 or Port 2) -> Use 1 for standard RJ11
    ' t1  = Pulse time in 2ms units (e.g., 50 -> 100ms)
    ' t2  = Same as t1 (sometimes ignored, often required)

    ' Using ESC p 0 25 25 (&H1B &H70 &H00 &H19 &H19) for 100ms pulse on Drawer 1
    ' In PosPrinterCommands.vb:
    Private ReadOnly ESC_POS_DRAWER_KICK As Byte() = New Byte() {&H1B, &H70, &H0, &H19, &H19}

    ''' <summary>
    ''' Sends a raw byte command directly to a printer.
    ''' </summary>
    ''' <param name="printerName">The name of the printer (must be installed on Windows).</param>
    ''' <param name="commandBytes">The byte array containing the command (e.g., ESC/POS code).</param>
    ''' <returns>True if the command was sent successfully, False otherwise.</returns>
    Public Function SendRawCommandToPrinter(ByVal printerName As String, ByVal commandBytes As Byte()) As Boolean
        Dim hPrinter As IntPtr = IntPtr.Zero
        Dim dwError As Integer = 0
        Dim docInfo As DOCINFOA
        Dim dwWritten As Integer = 0
        Dim bResult As Boolean = False

        ' 1. Open the printer.
        If OpenPrinter(printerName.Normalize(), hPrinter, IntPtr.Zero) Then
            docInfo.pDocName = "Cash Drawer Kick"
            docInfo.pOutputFile = Nothing
            docInfo.pDataType = "RAW"

            ' 2. Start a print job for raw data.
            If StartDocPrinter(hPrinter, 1, docInfo) > 0 Then
                ' 3. Start a page (required even for raw commands).
                If StartPagePrinter(hPrinter) Then

                    ' 4. Write the command bytes to the printer.
                    bResult = WritePrinter(hPrinter, commandBytes, commandBytes.Length, dwWritten)

                    ' 5. End the page and the document.
                    EndPagePrinter(hPrinter)
                    EndDocPrinter(hPrinter)

                Else
                    dwError = Marshal.GetLastWin32Error()
                    MessageBox.Show($"Error starting page for printer: {dwError}", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                dwError = Marshal.GetLastWin32Error()
                MessageBox.Show($"Error starting document for printer: {dwError}", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' 6. Close the printer.
            ClosePrinter(hPrinter)
        Else
            dwError = Marshal.GetLastWin32Error()
            MessageBox.Show($"Could not open printer {printerName}. Error code: {dwError}", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return bResult
    End Function

    ''' <summary>
    ''' Sends the ESC/POS command to open the cash drawer.
    ''' </summary>
    ''' <param name="printerName">The name of the POS printer as configured in Windows.</param>
    ''' <returns>True if the command was successfully sent.</returns>
    Public Function OpenCashDrawer(ByVal printerName As String) As Boolean
        Return SendRawCommandToPrinter(printerName, ESC_POS_DRAWER_KICK)
    End Function

End Module