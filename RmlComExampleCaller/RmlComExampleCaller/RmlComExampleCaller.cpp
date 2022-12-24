// RmlComExampleCaller.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <Windows.h>
#include <initguid.h>
#include <string>
#include "Utilities.h"

// A0C1C523-8307-4CD5-8566-180A55914EEC
DEFINE_GUID(CLS_IDCellphone, 0xa0c1c523, 0x8307, 0x4cd5, 
      0x85, 0x66, 0x18, 0x0a, 0x55, 0x91, 0x4e, 0xec);

// 08CED5FB-285D-4167-93CE-1E7376C35FD5
DEFINE_GUID(IID_IDevice, 0x08ced5fb, 0x285d, 0x4167, 
      0x93, 0xce, 0x1e, 0x73, 0x76, 0xc3, 0x5f, 0xd5);

// {10DC2A47-0351-460A-AF24-E77C81F854C3}
DEFINE_GUID(IID_IComPropertyExample, 
0x10dc2a47, 0x351, 0x460a, 0xaf, 0x24, 0xe7, 0x7c, 0x81, 0xf8, 0x54, 0xc3);

// {E3BE29B9-5DE6-44DF-8EFC-E58821236996}
DEFINE_GUID(CLSID_ComPropertyExample, 
0xe3be29b9, 0x5de6, 0x44df, 0x8e, 0xfc, 0xe5, 0x88, 0x21, 0x23, 0x69, 0x96);


void PrintCallErrorDetails(int hresult);

struct DeviceData
{
    __int32 DeviceIdentifier;
};

interface IDevice : IDispatch
{
    virtual __int32 __stdcall Test(DeviceData* devicePointer) = 0;
    virtual __int32 __stdcall Test2(DeviceData* devicePointer) = 0;
    virtual __int32 __stdcall Test3(DeviceData* devicePointer) = 0;
};

interface IComPropertyTest : IDispatch
{
    virtual __int32 __stdcall Test() = 0;
    virtual __int32 __stdcall get_State(int* getValue) = 0;
    virtual __int32 __stdcall set_State(int newValue) = 0;
    virtual __int32 __stdcall Test2() = 0;
};

bool InitializeCoCreateInstanceCellphone(void** ppv)
{
	auto hresult = CoCreateInstance(CLS_IDCellphone, NULL, CLSCTX_INPROC_SERVER, IID_IDevice, ppv);
    if (hresult < 0) {
        std::cout << "CoCreateInstance failed with status 0x" << std::hex << hresult << std::endl;
        return false;
    }
    return true;
}

bool InitializeCoGetClassObjectCellphone(void** ppv)
{
    LPVOID ppvTmp;
    auto hresult = CoGetClassObject(CLS_IDCellphone, CLSCTX_INPROC_SERVER, NULL, IID_IClassFactory, &ppvTmp);
    if (hresult < 0) {
        std::cout << "CoGetClassObject failed with status 0x" << std::hex << hresult << std::endl;
        return false;
    }

    IClassFactory* ppvFactory = (IClassFactory*)ppvTmp;
    hresult = ppvFactory->CreateInstance(NULL, IID_IDevice, &*ppv);
    if (hresult < 0) {
        std::cout << "IClassFactory::CreateInstance failed with status 0x" << std::hex << hresult << std::endl;
        return false;
    }

    return true;
}

void ComIDeviceTest()
{
    void* ppv = NULL;

    //if (!InitializeCoGetClassObject(&ppv))
    if (!InitializeCoCreateInstanceCellphone(&ppv))
        return;

    IDevice* device = (IDevice*)ppv;
    auto deviceData = DeviceData();
    deviceData.DeviceIdentifier = 55;
    std::cout << "deviceData address: " << &deviceData << " 0x" << std::hex << &deviceData << std::endl;

    try {
        auto hresult = device->Test(&deviceData);
        std::cout << "Called Test: 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call Test raised exception" << std::endl;
    }
    std::cout << std::endl;

    try {
        auto hresult = device->Test2(&deviceData);
        std::cout << "Called Test2: 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call Test2 raised exception" << std::endl;
    }
    std::cout << std::endl;

    try {
        auto hresult = device->Test3(&deviceData);
        std::cout << "Called Test3: 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call Test3 raised exception" << std::endl;
    }
    std::cout << std::endl;

    device->Release();
}


bool InitializeCoCreateInstanceComPropertyTest(void** ppv)
{
	auto hresult = CoCreateInstance(CLSID_ComPropertyExample, NULL, CLSCTX_INPROC_SERVER, IID_IComPropertyExample, ppv);
    if (hresult < 0) {
        std::cout << "CoCreateInstance failed with status 0x" << std::hex << hresult << std::endl;
        return false;
    }
    return true;
}


void ComIPropertyTest()
{
    void* ppv = NULL;

    if (!InitializeCoCreateInstanceComPropertyTest(&ppv))
        return;
    IComPropertyTest* icpt1 = (IComPropertyTest*)ppv;

    void* ppv2 = NULL;
    if (!InitializeCoCreateInstanceComPropertyTest(&ppv2))
    {
        icpt1->Release();
        return;
    }
    IComPropertyTest* icpt2 = (IComPropertyTest*)ppv2;

    int a = 5, b = 4;

    try {
        auto hresult = icpt1->set_State(a);
        std::cout << "Called icpt1->set_State: 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call icpt1->set_State raised exception" << std::endl;
    }
    std::cout << std::endl;

    try {
        auto hresult = icpt2->set_State(b);
        std::cout << "Called icpt2->set_State: 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call icpt2->set_State raised exception" << std::endl;
    }
    std::cout << std::endl;

    try {
        int c = 0;
        auto hresult = icpt1->get_State(&c);
        std::cout << "Called icpt1->get_State(" << c << "): 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call icpt1->get_State raised exception" << std::endl;
    }
    std::cout << std::endl;

    try {
        int c = 0;
        auto hresult = icpt2->get_State(&c);
        std::cout << "Called icpt2->get_State(" << c << "): 0x" << std::hex << hresult << std::endl;
        PrintCallErrorDetails(hresult);
    }
    catch (std::exception e) {
        std::cout << "Call icpt2->get_State raised exception" << std::endl;
    }
    std::cout << std::endl;
}

void PrintCallErrorDetails(int hresult)
{
    if (hresult >= 0) return;

	IErrorInfo* errorPpv;
    auto getErrorHresult = GetErrorInfo(NULL, &errorPpv);
    if (getErrorHresult == S_FALSE) {
        std::cout << "--> Error informations are not available" << std::endl;
        return;
    }

	BSTR description, source, helpFile;
	errorPpv->GetDescription(&description);
	GUID interfaceCulprit;
	errorPpv->GetGUID(&interfaceCulprit);
    errorPpv->GetSource(&source);
    errorPpv->GetHelpFile(&helpFile);

	OLECHAR* guidString;
	auto clsidToStringHresult = StringFromCLSID(interfaceCulprit, &guidString);
    std::cout << "--> [";
    std::wcout << guidString;
    std::cout << "] Failure reason : " << BstrToStdString(description) << std::endl;
    std::cout << "--> Help file: " << BstrToStdString(helpFile) << std::endl;
    std::cout << "--> Source: " << BstrToStdString(source) << std::endl;
}

int main()
{
    std::cout << "Press enter to test COM calls";
    getchar();

    CoInitialize(NULL);

    ComIDeviceTest();

    ComIPropertyTest();

    CoUninitialize();

    std::cout << "Press enter to exit" << std::endl;
    getchar();
    std::cout << "Exiting application" << std::endl;
}

