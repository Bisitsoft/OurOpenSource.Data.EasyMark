# EasyMark

An easy mark format.

跟名字一样是一个简易的标记方式，暂时不要指望有多太多的功能。

暂时不输出格式错误位置。

## 概述

其标准格式是`[ name( arg) ]`。
**注意：括号内侧各有一个空格，`name`和`arg`之间有且仅有一个空格或者没有`arg`，`arg`首位允许包含空格，而`name`不可以。**
**注意：`name`仅能由字母、数字和`_`构成。**

通过一对方括号来存储标记，标记内采用命令的格式来表达含义。

如`text[ img path ]`意思是在text后插入一个存储在`path`的图片。

通过`[[`和`]]`来转义。

## 自带标记

### img

`[ img <path> ]`

当前不支持格式，只支持存储文件位置。

`path`：图片的文件地址。

例：`[ img picture.png ]`

### comment

`[ remark <...> ]`

注释。

例：`[ comment 我是注释 ]`

### object

`[ object <mark> ]`

保留对象字段，对于未实现的内容进行保留。

`mark`：未实现的标记。**注意：开头不要有空格**

例：`[ object emoji =w= ]`

### data *（未实现）*

`[ data <data> ]`

保存数据。

`data`：含转义字符的数据。

例：`[ data Data\x64\u9999 ]`