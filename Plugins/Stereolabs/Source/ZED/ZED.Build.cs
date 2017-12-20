// Copyright 1998-2016 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;
using System;

public class ZED : ModuleRules
{
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    public string ProjectConfigPathDirectory
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../../../../Saved/Config/ZED/")); }
    }

    public ZED(ReadOnlyTargetRules Target) : base(Target)
    {
        PublicIncludePaths.AddRange(
            new string[] {
                "ZED/Public"

				// ... add public include paths required here ...
			}
            );


        PrivateIncludePaths.AddRange(
            new string[] {
				"ZED/Private"
				
				// ... add other private include paths required here ...
			}
            );

        PublicDependencyModuleNames.AddRange(
            new string[]
			{
                 "Stereolabs",
                 "MixedReality",

                 "UMG",
                 "Slate",
                 "SlateCore"

				// ... add other public dependencies that you statically link with here ...
			}
            );

        PrivateDependencyModuleNames.AddRange(
            new string[] 
            {
                "Core",
                "CoreUObject",

                "Engine", 

                "RenderCore",
                "ShaderCore",
                "InputCore",

                "HeadMountedDisplay",

                "RHI", 
                "D3D11RHI"
            }
            );

        string ZedConfigFileName = "ZED.ini";
        string CameraConfigFileName = "Camera.ini";

        string ZedConfigFilePath = ProjectConfigPathDirectory + ZedConfigFileName;
        string CameraConfigFilePath = ProjectConfigPathDirectory + CameraConfigFileName;

        if (!Directory.Exists(ProjectConfigPathDirectory))
        {
            Directory.CreateDirectory(ProjectConfigPathDirectory);
        }

        if (!File.Exists(ZedConfigFilePath))
        {
            File.Copy(Path.Combine(ModulePath, "Defaults", ZedConfigFileName), ZedConfigFilePath, true);
        }
        if (!File.Exists(CameraConfigFilePath))
        {
            File.Copy(Path.Combine(ModulePath, "Defaults", CameraConfigFileName), CameraConfigFilePath, true);
        }

        // Copy config file to shipped folder
        if (Target.Type != TargetRules.TargetType.Editor)
        {
            RuntimeDependencies.Add(ZedConfigFilePath, StagedFileType.NonUFS);
            RuntimeDependencies.Add(CameraConfigFilePath, StagedFileType.NonUFS);
        }

        // Calibration settings
        String MRFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Stereolabs\\mr");

        if (!Directory.Exists(MRFolderPath))
        {
            Directory.CreateDirectory(MRFolderPath);
        }

        String CalibrationFilePathDefinition = "ZED_CALIBRAITON_FILE_PATH=" + "\"" + MRFolderPath + "\\Calibration.ini" + "\"";
        CalibrationFilePathDefinition = CalibrationFilePathDefinition.Replace("\\", "/");

        Definitions.Add(CalibrationFilePathDefinition);
    }
}