# C# 基础 - 语法

### 标识符 Identifier

+ 标识符结算程序员给他们所写的类、方法、变量等起的名字
+ 标识符必须是一个完整的单词，它是由 Unicode 字符组成的，并且由字母或者下划线开头

### 关键字 Keyword

+ 关键字就是对编译器有特殊意义的一些名字 例如： using, class, static, void, int
+ **大部分关键字都是保留的** 意思是你不可以把它们当作标识符来用 （特殊情况时可以使用 @ 前缀将 关键字 转化为 标识符 使用）
+ [关键词列表](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/)
+ **上下文关键字**
    + 上下问关键字用于在代码中提供特定含义，但不是 C# 中的保留字。一些上下文关键字（如 partial 和 where）在两个或多个上下文中有特殊含义。
    + [上下文关键词列表](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/#contextual-keywords)

### 字面量 Literal 、标点符号 、操作符

+ 字面量 常规的数字等 例如： 0123456789 等数字
+ 标点符号 尽可能以英文符号为准 例如： ; ,
+ 操作符 例如： + - * / = ==

### 注释

+ // 单行注释
+ /* 多行注释 */
+ 注释符号后 加空格 养成好习惯，方便阅读