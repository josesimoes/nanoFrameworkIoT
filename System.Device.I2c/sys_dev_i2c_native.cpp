//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

#include "sys_dev_i2c_native.h"


static const CLR_RT_MethodHandler method_lookup[] =
{
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    Library_sys_dev_i2c_native_System_Device_I2c_I2cController::NativeInit___VOID,
    NULL,
    NULL,
    Library_sys_dev_i2c_native_System_Device_I2c_I2cController::GetDeviceSelector___STATIC__STRING,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    Library_sys_dev_i2c_native_System_Device_I2c_I2cDevice::NativeInit___VOID,
    Library_sys_dev_i2c_native_System_Device_I2c_I2cDevice::NativeDispose___VOID__BOOLEAN,
    Library_sys_dev_i2c_native_System_Device_I2c_I2cDevice::NativeTransmit___WindowsDevicesI2cI2cTransferResult__SZARRAY_U1__SZARRAY_U1,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
    NULL,
};

const CLR_RT_NativeAssemblyData g_CLR_AssemblyNative_System_Device_I2c =
{
    "System.Device.I2c",
    0x79EDBF71,
    method_lookup,
    { 100, 2, 0, 2 }
};
