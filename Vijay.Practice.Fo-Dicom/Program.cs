using Dicom;
using FellowOakDicom.Imaging.Reconstruction;
using System.Diagnostics;

public class Program
{
    private static readonly string PathToDicomTestFile = @".\test1.dcm";

    public static void Main(string[] args)
    {
        //Example1();
        Example2();
    }

    public static void Example2()
    {
        try
        {
            LogToDebugConsole($"Attempting to extract information from DICOM file:{PathToDicomTestFile}...");
            var file = DicomFile.Open(PathToDicomTestFile);
            foreach (var tag in file.Dataset)
            {
                LogToDebugConsole($" {tag} '{file.Dataset.GetValueOrDefault(tag.Tag, 0, "")}'");
            }
            LogToDebugConsole($"Extract operation from DICOM file successful");
        }
        catch (Exception e)
        {
            LogToDebugConsole($"Error occured during DICOM file dump operation -> {e.StackTrace}");
        }
    }

    public static void Example1()
    {
        try
        {
            LogToDebugConsole($"Attempting to extract information from DICOM file:{PathToDicomTestFile}...");

            var file = DicomFile.Open(PathToDicomTestFile, readOption: FileReadOption.ReadAll);
            var dicomDataset = file.Dataset;
            var studyInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.StudyInstanceUID);
            var seriesInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.SeriesInstanceUID);
            var sopClassUid = dicomDataset.GetSingleValue<string>(DicomTag.SOPClassUID);
            var sopInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.SOPInstanceUID);
            var transferSyntaxUid = file.FileMetaInfo.TransferSyntax;

            LogToDebugConsole($" StudyInstanceUid - {studyInstanceUid}");
            LogToDebugConsole($" SeriesInstanceUid - {seriesInstanceUid}");
            LogToDebugConsole($" SopClassUid - {sopClassUid}");
            LogToDebugConsole($" SopInstanceUid - {sopInstanceUid}");
            LogToDebugConsole($" TransferSyntaxUid - {transferSyntaxUid}");

            LogToDebugConsole($"Extract operation from DICOM file successful");
        }
        catch (Exception e)
        {
            LogToDebugConsole($"Error occured during DICOM file dump operation -> {e.StackTrace}");
        }
    }

    public static void LogToDebugConsole(string informationToLog)
    {
        Console.WriteLine(informationToLog);
    }
}