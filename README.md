# ScreenTransition

## スクロール＆省略記号表示ラベル
表示文字列が表示可能幅を越えるとスクロール可能となり、文字列の全てを確認できるラベル。

![スクロール可能ラベル](Images/ScrollableLabel.gif)

サンプルソース：ScreenTransition/Views/ScrollableLabelSamplePage.xaml

### 対象ソース
* ScreenTransition/Controls/ScrollableLabel.xaml
* ScreenTransition/Controls/ScrollableLabel.xaml.cs

### 使い方

1. 対象ソースをPCLプロジェクトに配置する。
2. ScrollableLabelを配置し、プロパティを指定する。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage
    (略)
    xmlns:controls="clr-namespace:ScreenTransition.Controls">
    <ContentPage.Content>
        <controls:ScrollableLabel
            BackgroundColor="White"
            Text="長い文字列" />
    </ContentPage.Content>
</ContentPage>
```

|プロパティ|説明|
|---|---|
|Text|ラベルに表示する文字列を設定する。|
|BackgroundColor|背景色を設定する。<br>省略記号「...」の背景色でもあるので必ず指定してください。<br>（改善したい。。。）|

---
## 複数行タイトルバー
タイトルバーに最大3つのタイトル行を表示するタイトルバー。<br>
タイトル行数に合わせてフォントサイズを自動調整する。<br>
タイトルが1行に表示しきれない場合はスクロールでタイトルを確認することが可能。（ScrollableLabel使用。文字色、背景色は祖先のNavigationPageのそれとバインディングしているので自動的に連動する。）

![複数行タイトルバー1](Images/MultiLineTitleBar01.gif)

![複数行タイトルバー1](Images/MultiLineTitleBar02.gif)

サンプルソース：ScreenTransition/Views/MultiLineTitleSamplePage.xaml

### 対象ソース
* ScreenTransition/Controls/MultiLineTitleView.xaml
* ScreenTransition/Controls/MultiLineTitleView.xaml.cs
* ScreenTransition/Controls/ScrollableLabel.xaml
* ScreenTransition/Controls/ScrollableLabel.xaml.cs

### 使い方

1. 対象ソースをPCLプロジェクトに配置する。
2. 複数行タイトルバーを表示したいページのNavigationPage.TitleViewにMultiLineTitleViewを配置し、プロパティを指定する。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage
    (略)
    x:Class="ScreenTransition.Views.MultiLineTitleSamplePage">

    <NavigationPage.TitleView>
        <controls:MultiLineTitleView
            Title1="1行目に表示したいタイトル文字列"
            Title2="1行目に表示したいタイトル文字列"
            Title3="1行目に表示したいタイトル文字列"/>
    </NavigationPage.TitleView>
    (略)
</ContentPage>
```

|プロパティ|説明|
|---|---|
|Title1|1行目に表示したいタイトル文字列を設定する。|
|Title2|2行目に表示したいタイトル文字列を設定する。|
|Title3|3行目に表示したいタイトル文字列を設定する。|
タイトル文字列を指定しない（文字列長0）の場合、そのタイトル行を非表示とする。
