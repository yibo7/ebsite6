# css 
bootstrap.css支持所有的功能，其他的css只支持四个功能的一部分。
所以在开发中，除特殊情况，我们基本都引用:
> bootstrap.min.css。

# js
js的文件有bootstrap和bootstrap.bundle
bootstrap.bundle 是比较完整的库
bootstrap.bundle.js包含了popper.js这个框架。
当我们在项目中引入bootstrap.bundle.min.js而不是bootstrap.min.js时，就不需要在前面引入popper.js。
