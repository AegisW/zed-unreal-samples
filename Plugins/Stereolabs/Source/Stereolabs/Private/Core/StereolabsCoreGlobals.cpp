#include "StereolabsPrivatePCH.h"
#include "Stereolabs/Public/Core/StereolabsCoreGlobals.h"
#include "Stereolabs/Public/Core/StereolabsCameraProxy.h"

uint32 GSlGrabThreadId = 0;

bool GSlIsGrabThreadIdInitialized = false;

float GSlEyeHalfBaseline = 0.0f;

USlCameraProxy* GSlCameraProxy = nullptr;