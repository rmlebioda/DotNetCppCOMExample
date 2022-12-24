// RmlComExampleCaller.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <Windows.h>
#include <initguid.h>
#include <string>
#include "Utilities.h"

// A0C1C523-8307-4CD5-8566-180A55914EEC
DEFINE_GUID(Cellphone_CLSID, 0xa0c1c523, 0x8307, 0x4cd5, 
      0x85, 0x66, 0x18, 0x0a, 0x55, 0x91, 0x4e, 0xec);

// 08CED5FB-285D-4167-93CE-1E7376C35FD5
DEFINE_GUID(IID_IDevice, 0x08ced5fb, 0x285d, 0x4167, 
      0x93, 0xce, 0x1e, 0x73, 0x76, 0xc3, 0x5f, 0xd5);

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

bool InitializeCoCreateInstance(void** ppv)
{
	auto hresult = CoCreateInstance(Cellphone_CLSID, NULL, CLSCTX_INPROC_SERVER, IID_IDevice, ppv);
    if (hresult < 0) {
        std::cout << "CoCreateInstance failed with status 0x" << std::hex << hresult << std::endl;
        CoUninitialize();
        return false;
    }
    return true;
}

bool InitializeCoGetClassObject(void** ppv)
{
    LPVOID ppvTmp;
    auto hresult = CoGetClassObject(Cellphone_CLSID, CLSCTX_INPROC_SERVER, NULL, IID_IClassFactory, &ppvTmp);
    if (hresult < 0) {
        std::cout << "CoGetClassObject failed with status 0x" << std::hex << hresult << std::endl;
        CoUninitialize();
        return false;
    }

    IClassFactory* ppvFactory = (IClassFactory*)ppvTmp;
    hresult = ppvFactory->CreateInstance(NULL, IID_IDevice, &*ppv);
    if (hresult < 0) {
        std::cout << "IClassFactory::CreateInstance failed with status 0x" << std::hex << hresult << std::endl;
        CoUninitialize();
        return false;
    }

    return true;
}

void ComTest()
{
    CoInitialize(NULL);

    void* ppv = NULL;

    //if (!InitializeCoGetClassObject(&ppv))
    if (!InitializeCoCreateInstance(&ppv))
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

    CoUninitialize();
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

    ComTest();

    std::cout << "Press enter to exit" << std::endl;
    //std::string dummy;
    //std::cin >> dummy;
    //if (std::cin.fail()) {
    //    std::cout << "std::cin failed" << std::endl;
    //}
    getchar();
    std::cout << "Exiting application" << std::endl;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
