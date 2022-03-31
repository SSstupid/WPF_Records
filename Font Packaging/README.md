# WPF Font Packaging
### 글꼴 패키징
* 글꼴 패키징을 이해하고 수정하여 적용한다.
<br />    


 ## 컨텐츠
- [개발정보](#개발정보)
- [프로젝트 구조](#프로젝트-구조)
- [개요](#개요)
- [목차](#목차)
- [스크린샷](#스크린샷)             
<br />

# 개발정보
* .NET 6.0
* C# 10.0
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

## 목차  
* 글꼴 패키징     
  * 콘텐츠 항목으로 글꼴 추가
  * 리소스 항목으로 글꼴 추가
  * 코드에서 글꼴 리소스 항목 참조
* 애플리케이션의 글꼴 열거
* 글꼴 리소스 라이브러리
* 글꼴 연구진행과정
* 디자이너 오류
<br />

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
<br /> 

  * 글꼴 추가와 동시 배포 디렉토리에 복사
```
<ItemGroup>
  <Content Include="./Fonts/Vanisha.ttf">
     <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory> <!-- 배포 디렉토리에 복사 -->
  </Content>
</ItemGroup>
```
 "<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory> "문을 추가하여 배포 디렉토리에 복사 할 수있다.  
<br />

```
<TextBlock FontFamily="./Fonts/#Vanisha" Text="Vanisha" />     <!-- 콘텐츠로 참조-->
<TextBlock FontFamily="./Resource/#orange juice Text="orange juice" /> <!-- 리소스로 참조 -->
```
MainWoindow.xaml에 위의 소스를 사용하여 글꼴을 참조한다.  
<br /> 
   
* 코드에서 글꼴 리소스 항목 참조
```
//MainWindow.xaml.cs 
myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Resource/#Athletic Outfit"); //myTextBlock => TextBlock의 X:Name
```
 
<br /> 
   
## 애플리케이션의 글꼴 열거
* .NET Framework 4.8까지 지원하지만 .NET 6.0에서도 돌아갑니다.   
```
(MainWindow.xaml.cs)
System.Collections.Generic.ICollection<FontFamily> fontFamilies = Fonts.GetFontFamilies(new Uri("pack://application:,,,/Resource/#"));

foreach (FontFamily fontFamily in fontFamilies)
{
    string[] familyName = fontFamily.Source.Split('#');
    ListView.Items.Add(familyName[familyName.Length - 1]); // 리스트아이템 추가
}
```   

![글꼴리스트](https://user-images.githubusercontent.com/90036120/160578650-36870500-96b1-4b73-9426-de817c87f9c4.JPG)   

 지정된 경로에 있는 모든 글꼴을 리스트 아이템에 추가 할 수 있다. (다양한 방식으로 이용하능 할 것 같습니다.)
<br /> 

*  Typeface 개체의 컬렉션 반환.
```
foreach (Typeface typeface in Fonts.GetTypefaces(new Uri("pack://application:,,,/Resource/#"))) //(new Uri("글꼴 경로")
 {
   //예제파일 <TextBlock x:Name="myTextBlock" Text="코드에서 참조" FontSize="22" Margin="0,10,0,20"/>에서 확인 하실 수 있습니다.
 }
```  
<br /> 

## 글꼴 리소스 라이브러리
프로젝트에 -추가 -새항목 -리소스 사전 을 생성합니다. Ex) /Style/Font.xaml (Style폴더에 리소스사전 Fonts라는 이름으로 생성합니다.)
```
<FontFamily x:Key="FontXaml1">pack://application:,,,/Fonts/#How Lovely</FontFamily>
```
생성한 리소스 사전에 위의 소스를 추가  
<br /> 

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
<br /> 

```
<TextBlock FontFamily="{StaticResource FontXaml1}" Text="Font.xaml ResourceDictionary / 리소스 사전 참조"/>  <!--StaticResource '지정한 x:key' -->
```
(MainWindow.xaml.cs)  
<br /> 

## 글꼴 연구진행과정
* 글꼴 추가시 경로 설정
```
<Content Include="./Resource/napBlock.ttf" />
<Content Include="Resource/Vanisha.ttf" />
```
(.csproj) 글꼴 추가시 "./"을 생략해도 문제없이 경로설정이 됩니다.  
<br /> 

* 글꼴 참조시 경로설정
```
<TextBlock FontFamily="./Resource/#Vanisha" Text="Ex) 1" />
<TextBlock FontFamily="#Vanisha" Text="Ex) 2" />
<TextBlock FontFamily="Vanisha" Text="Ex) 3" />
```
글꼴 참조시 경로를 명시적, 암시적으로 모두 표현가능 합니다.
Ex) "./Resource/#Vanisha" => "#Vanisha" => "Vanisha"   
    
이것을 이용하여 테스트를 해봅니다.  
=> 암시적 표현 테스트   
![Hide](https://user-images.githubusercontent.com/90036120/160573820-5484ca28-cdd0-4a76-980e-5f43b22992d9.JPG)     
글꼴 위치를 폴더로 싸서 숨깁니다.  

```
<!-- MainWindow.xaml -->
<Window.Resources>
        <FontFamily x:Key="Windowxaml4" >Lato Thin ltaic</FontFamily> 
</Window.Resources>
 ...  
<TextBlock FontFamily="{StaticResource Windowxaml4}" Text="폰트경로 암시적 표현" FontSize="22" />
```    
Window.Resources에 글꼴을 추가하고 참조하여 불러옵니다.  
.   
![암시적](https://user-images.githubusercontent.com/90036120/160574896-e072f579-59c8-4365-9d43-62ed65e54694.JPG)   
이렇게 욕이 나올정도로 경로 설정을 때도,   
잘 적용이 됩니다.
<br />

* App.xaml, MainWindow.xaml 리소스 추가
다음은 xaml에 리소스를 추가하여 폰트를 참조하는 방법입니다.
```
<Application.Resources>
     <ResourceDictionary>
         <FontFamily x:Key="AppXaml">/Resource/#orange juice </FontFamily> <!-- App.xaml에 글꼴 추가 -->
     </ResourceDictionary>
</Application.Resources>
```
App.xaml에 글꼴을 추가합니다.   

```
<Window.Resources>
     <FontFamily x:Key="Windowxaml1" >/Fonts/#가비아 솔미체</FontFamily>
</Window.Resources>
```
MainWindow.xaml에 글꼴을 추가합니다.  

참조방법  
```
<TextBlock FontFamily="{StaticResource Windowxaml1}" Text="Wiondow.xaml Resource / Window 리소스 참조" />
<TextBlock FontFamily="{StaticResource AppXaml}" Text="App.xaml Resource / App 리소스 참조" />
```   
<br />

* Style에 글꼴 추가, 참조
```
<Application.Resources>
     <ResourceDictionary>
         <Style x:Key="AppStyle" TargetType="{x:Type TextBlock}">
              <Setter Property="FontFamily" Value="Fonts/napBlock.ttf #NapjakBlock" />
         </Style>
     </ResourceDictionary>
</Application.Resources>
```
App.xaml에 Style을 설정합니다.  
```
<TextBlock Style="{StaticResource AppStyle}" Text="AppStyle ResourceDictionary / App Style 참조" />
```
Style을 참조하여 글꼴을 불러올 수 있습니다.    
<br />

* 디자이너 오류
![다지인디버깅비교](https://user-images.githubusercontent.com/90036120/160580008-f81901c1-cfee-462e-bf50-ecd641af428b.jpg)   
(왼쪽이 디자이너, 오른쪽이 디버깅시 모습입니다)
디자이너에서 글꼴이 적용이 되었지만 디버깅시 글꼴 적용이 안되는 현상입니다.   
실험해본 결과 .csproj에 리소스를 추가 할시 적용이됩니다.
```
<Resource Include="Resource/폰트 경로.ttf" /> <!-- 디버깅시 적용되지 않는 글꼴을 리소스에 추가 해줍니다. -->
```
여기서 재미있는건 예외로 <Window.Resources>로 글꼴 추가 시 등등의 경우는 오류가 나지 않습니다.    
<br />

# 스크린샷
![스크린샷1](https://user-images.githubusercontent.com/90036120/160582203-bdfe9fb9-1c91-4c92-93d6-b179037b0c21.JPG)    
<br />
-----------------
![스크린샷2](https://user-images.githubusercontent.com/90036120/160582218-71a0516f-7245-4873-9131-ce5547fd5226.JPG)  

참조 : https://docs.microsoft.com/ko-kr/dotnet/desktop/wpf/advanced/packaging-fonts-with-applications?view=netframeworkdesktop-4.8#introduction-to-packaging-fonts
