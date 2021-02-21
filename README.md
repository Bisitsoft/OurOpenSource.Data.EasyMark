# EasyMark

An easy mark format.

跟名字一样是一个简易的标记方式，暂时不要指望有多太多的功能。

暂时不输出格式错误位置。

## 概述

**主要命名空间为`OurOpenSource.Data.EasyMark`。**

通过一对方括号来存储标记，标记内采用命令的格式来表达含义。

其标准格式是`[ name( arg) ]`。
**注意：括号内侧各有一个空格，`name`和`arg`之间有且仅有一个空格或者没有`arg`，`arg`首尾允许包含空格，而`name`不可以。**
**注意：`name`仅能由字母、数字和`_`构成。**

如`text[ img path ]`意思是在text后插入一个存储在`path`的图片。

通过`[[`和`]]`来转义。

## 教程

### 快速开始

```
//引用库。
using System; //Console在其中
using OurOpenSource.Data.EasyMark;
//...
//初始化`EasyMarksManager`。
OurOpenSource.Data.EasyMark.Marks.EasyMarksManager.Initialization();
//将处理过后的EasyMark原文本存放到`doc`中。
MarkedEasyMark doc = EasyMarkLoader.ProcessEasyMark("EasyMark Document Text");
//输出转义过后的EasyMark文本。
Console.WriteLine(doc.Text);
//...
```

### 加载EasyMark文件（UI库）

```
//引用库。
using OurOpenSource.Data.EasyMark;
using OurOpenSource.Data.EasyMark.WPF;
//...
//初始化`EasyMarksManager`。
OurOpenSource.Data.EasyMark.Marks.EasyMarksManager.Initialization();
//将处理过后的EasyMark原文本存放到`doc`中。
MarkedEasyMark doc = EasyMarkLoader.ProcessEasyMark("EasyMark Document Text");
//创建一个`EasyMarkRenderer`
EasyMarkRenderer easyMarkRenderer = new EasyMarkRenderer();
//架设窗口中有一个名为`grid`的`Grid`。
//添加`easyMarkRenderer`到grid中。
grid.Children.Add(easyMarkRenderer);
//渲染EasyMark文档。
easyMarkRenderer.Render(doc);
//...
```

## 标记类型

### comment

`[ cmt <...> ]`

注释。

例：`[ cmt 我是注释 ]`

### data *（未实现）*

`[ dat <data> ]`

保存数据。

`data`：可以含有转义字符的字符串。

例：`[ dat Data\x64\u9999 ]`

### image

`[ img <path> ]`

当前不支持格式，只支持存储文件位置。

`path`：图片的文件地址。

例：`[ img picture.png ]`

**因为目前整段`arg`有用于表达`path`所以不要加`""`来包括`path`！**

### object

`[ obj <mark> ]`

保留对象字段，对于未实现的内容进行保留。

`mark`：未实现的标记。**注意：开头不要有空格**

例：`[ obj emoji =w= ]`

## 其他

`NPP_UDL_EasyMark.xml`是用于Notepad++的用户自定义语言文件。