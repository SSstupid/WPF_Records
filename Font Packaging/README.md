# WPF Font Packaging
### 글꼴 패키징
* 패키징을 이해하고 수정하여 적용한다.
<br />    


 ## 컨텐츠
- [소스특징](#소스특징)
- [개발정보](#개발정보)
- [프로젝트 구조](#프로젝트-구조)
- [개요](#개요)
- [스크린샷](#스크린샷)             
<br />

# 소스특징  
* 글꼴 패키징     
  * 콘텐츠 항목으로 글꼴 추가
  * 리소스 항목으로 글꼴 추가
  * 코드에서 글꼴 리소스 항목 참조
* 애플리케이션의 글꼴 열거
* 글꼴 리소스 라이브러리
* 글꼴 연구진행과정
* 디자이너 오류
<br />

# 개발정보
* .NET 6.0
* C# 10.0 ↑
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/ko/vs/preview/)
<br />

# 프로젝트 구조
* 📁 Fonts
  * 폰트 .ttf 파일
* 📁 Hide
* 📁 Resource
* 📁 Style
  * Font.xaml
* App.xaml
* .csproj
<br />

# 개요
## 글꼴 패키징
* 콘텐츠항목으로 글꼴 추가
```
<ItemGroup>
   <Content Include="./Fonts/Vanisha.ttf" /> <!-- "./Fonts/Vanisha.ttf" => 글꼴파일 경로-->
</ItemGroup>
```
.csproj에 위의 소스를 추가   
<br />     
      
   * 리소스 항목으로 글꼴 추가
```
<ItemGroup>
   <Resource Include="Resource/orange-juice.ttf" />
</ItemGroup>
```
.csproj에 위의 소스를 추가

  * 글꼴 추가와 동시 배포 디렉토리에 복사
```
<ItemGroup>
  <Content Include="./Fonts/Vanisha.ttf">
     <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory> 
  </Content>
</ItemGroup>
```
<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory> 문을 추가하여 배포 디렉토리에 복사 할 수있다.

<br />


```
<TextBlock FontFamily="./Fonts/#Vanisha" Text="Vanisha" />     <!-- 콘텐츠 참조-->
<TextBlock FontFamily="./Resource/#orange juice Text="orange juice" /> <!-- 리소스 참조 -->
```
MainWoindow.xaml에 위의 소스를 사용하여 글꼴을 참조한다.
   
* 코드에서 글꼴 리소스 항목 참조
```
myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Resource/#Athletic Outfit"); //myTextBlock => TextBlock의 X:Name
```
MainWindow.xaml.cs
   
* 애플리케이션의 글꼴 열거
```
System.Collections.Generic.ICollection<FontFamily> fontFamilies = Fonts.GetFontFamilies(new Uri("pack://application:,,,/Resource/#"));

foreach (FontFamily fontFamily in fontFamilies)
{
    string[] familyName = fontFamily.Source.Split('#');
    ListView.Items.Add(familyName[familyName.Length - 1]); // 리스트아이템 추가
}
```
(MainWindow.xaml.cs) 리스트부에 지정된 경로에 있는 모든 글꼴을 리스트 아이템에 추가 할 수 있다.

*  Typeface 개체의 컬렉션 반환.
```
foreach (Typeface typeface in Fonts.GetTypefaces(new Uri("pack://application:,,,/Resource/#"))) //(new Uri("글꼴 경로")
 {
 }
```

* 글꼴 리소스 라이브러리
프로젝트에 -추가 -새항목 -리소스 사전 을 생성합니다. Ex) /Style/Font.xaml (Style폴더에 리소스사전 Fonts라는 이름으로 생성합니다.)
```
<FontFamily x:Key="FontXaml1">pack://application:,,,/Fonts/#How Lovely</FontFamily>
```
생성한 리소스 사전에 위의 소스를 추가
```
<Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="./Style/Font.xaml" /> <!-- 리소스사전 경로-->
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
```
App.xaml을 통해 추가한 리소스 사전을 참조합니다.

```
<TextBlock FontFamily="{StaticResource FontXaml1}" Text="Font.xaml ResourceDictionary / 리소스 사전 참조"/>  <!--StaticResource '지정한 x:key' -->
```
(MainWindow.xaml.cs)


<br />
# 스크린샷
<img src=https://user-images.githubusercontent.com/90036120/159855380-1c357214-b05f-449a-a43d-4ceaa9a1fcee.JPG width="750" height="400"/>.
<br />






