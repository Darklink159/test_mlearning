<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="MLearning.Cloud" generation="1" functional="0" release="0" Id="27c5ebe2-0713-43c5-8416-6616f6919496" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="MLearning.CloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="MVC:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/MLearning.Cloud/MLearning.CloudGroup/LB:MVC:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="MVC:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MapMVC:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="MVCInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MapMVCInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:MVC:Endpoint1">
          <toPorts>
            <inPortMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVC/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapMVC:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVC/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapMVCInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVCInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="MVC" generation="1" functional="0" release="0" software="C:\Test\Projects\MLearning.Cloud\MLearning.Cloud\csx\Debug\roles\MVC" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="768" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;MVC&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;MVC&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVCInstances" />
            <sCSPolicyUpdateDomainMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVCUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVCFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="MVCUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="MVCFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="MVCInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="ba45231f-cd00-4d3c-afc8-a07134793cb4" ref="Microsoft.RedDog.Contract\ServiceContract\MLearning.CloudContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="6d46f89b-7d84-47d8-b888-3192f80c9192" ref="Microsoft.RedDog.Contract\Interface\MVC:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/MLearning.Cloud/MLearning.CloudGroup/MVC:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>