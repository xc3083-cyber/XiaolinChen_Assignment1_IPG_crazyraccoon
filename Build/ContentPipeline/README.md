# 素材构建的路径修复

这个项目使用 MonoGame 3.8.5.1。在当前 Windows 环境中，默认图片导入器读取包含中文父目录的绝对路径时，会对实际存在的 PNG 报 `The file was not found`。

`RelativeTextureImporter` 先将图片路径改成相对于素材工作目录的路径，例如 `player_01.png`，再交给原来的导入器处理。PNG 文件名和相对于 Content 的子目录应使用英文或数字。

这部分只参与构建，不属于玩家、雨滴或浣熊的游戏逻辑。游戏中的 `Content.Load<Texture2D>("player_01")` 写法保持不变。

在项目根目录运行：

```powershell
dotnet tool restore
dotnet build IPG_Assignment2.csproj
```

主项目会先编译此扩展，再将 DLL 放入 `Content/obj/ContentPipeline`，最后构建素材。首次打开 MGCB Editor 前，请先构建一次主项目。之后新增 PNG 时，在编辑器的 Importer 属性中选择 `Texture Importer - Relative Path`。

扩展与 MGCB 的运行时保持一致，使用 net8.0；游戏本身仍使用 net9.0。MonoGame 包和本地工具版本应一起更新。
