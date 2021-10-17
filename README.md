# Twelite Cue　の標準APPの受信をC#で使う

Tweliteは、 https://mono-wireless.com/jp/products/TWE-LITE/index.html
受信フォーマットは、　https://wings.twelite.info/how-to-use/parent-mode/receive-message/app_cue

tweliteCueフォルダ内のtweliteCue.csをCopyして使ってください。
.NET COREは、シリアルポートの利用するので、Package.appxmanifestにシリアルポートの使う宣言が必要です。

```
<Capabilities>
    <DeviceCapability Name="serialcommunication" >
      <Device Id="any">
        <Function Type="name:serialPort"/>
      </Device>
    </DeviceCapability>
  </Capabilities>
```

