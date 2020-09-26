//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

#ifndef _SYS_DEV_I2C_NATIVE_H_
#define _SYS_DEV_I2C_NATIVE_H_

#include <nanoCLR_Interop.h>
#include <nanoCLR_Runtime.h>
#include <nanoCLR_Checks.h>

///////////////////////////////////////////////////////////////////////////////////////
// !!! KEEP IN SYNC WITH System.Device.I2c.I2cTransferStatus (in managed code) !!! //
///////////////////////////////////////////////////////////////////////////////////////
 enum I2cTransferStatus
{
    I2cTransferStatus_FullTransfer = 0,
    I2cTransferStatus_ClockStretchTimeout,
    I2cTransferStatus_PartialTransfer,
    I2cTransferStatus_SlaveAddressNotAcknowledged,
    I2cTransferStatus_UnknownError
};

///////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////

struct Library_sys_dev_i2c_native_System_Device_I2c_I2cConnectionSettings
{
    static const int FIELD___deviceAddress = 1;
    static const int FIELD___busId = 2;
    //--//

};

struct Library_sys_dev_i2c_native_System_Device_I2c_I2cController
{
    static const int FIELD___syncLock = 1;
    static const int FIELD___controllerId = 2;
    static const int FIELD__s_deviceCollection = 3;

    NANOCLR_NATIVE_DECLARE(NativeInit___VOID);
    NANOCLR_NATIVE_DECLARE(GetDeviceSelector___STATIC__STRING);

    //--//

};

struct Library_sys_dev_i2c_native_System_Device_I2c_I2cControllerManager
{
    static const int FIELD_STATIC___syncLock = 0;
    static const int FIELD_STATIC__s_controllersCollection = 1;

    //--//

};

struct Library_sys_dev_i2c_native_System_Device_I2c_I2cTransferResult
{
    static const int FIELD___bytesTransferred = 1;
    static const int FIELD___status = 2;

    //--//

};

struct Library_sys_dev_i2c_native_System_Device_I2c_I2cDevice
{
    static const int FIELD___syncLock = 1;
    static const int FIELD___deviceId = 2;
    static const int FIELD___connectionSettings = 3;
    static const int FIELD___disposed = 4;

    NANOCLR_NATIVE_DECLARE(NativeInit___VOID);
    NANOCLR_NATIVE_DECLARE(NativeDispose___VOID__BOOLEAN);
    NANOCLR_NATIVE_DECLARE(NativeTransmit___WindowsDevicesI2cI2cTransferResult__SZARRAY_U1__SZARRAY_U1);

    //--//

};

extern const CLR_RT_NativeAssemblyData g_CLR_AssemblyNative_System_Device_I2c;

#endif  //_WIN_DEV_I2C_NATIVE_H_
