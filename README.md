README.md
 
markdown
  
# UnityWebRequest‑Demo
> 本项目为 Unity 网络请求入门示例，采用 Node.js + Express 搭建本地调试服务器。
> 演示 GET 请求、参数传递、文本配置下载、图片资源下载保存等功能。

## 📂 项目目录结构
 
 
├─ WebServer/            # Node后端服务目录
│  ├─ main.js            # Express服务入口脚本
│  └─ www_root/          # 静态资源文件夹（服务器根目录）
│     ├─ Version.txt     # 版本配置文本
│     └─ Photo/
│        └─ laoda.png    # 待下载的图片资源
└─ UnityScripts/
└─ GameApp.cs         # Unity客户端测试脚本
 
plaintext
  

## ✨ 实现功能列表
1. 访问公网接口（示例：访问百度）
2. 调用本地后端GET接口，URL携带查询参数
3. 从服务端下载文本配置文件，读取版本信息
4. 下载二进制图片文件，保存至Unity本地持久化目录

## 🛠 环境依赖
- Node.js v16 及以上版本
- Express 模块
- Unity 2021+

安装依赖
```shell
cd WebServer
npm install express
 
 
🚀 运行步骤
 
1. 启动后端服务器
 
powershell
  
cd WebServer
node .\main.js
 
 
控制台输出  服务器启动，端口6080  代表启动成功。
 
保持该终端窗口运行，关闭窗口服务随即停止。
 
2. Unity编辑器配置
 Edit  →  Project Settings  →  Player  →  Other Settings 
 Allow downloads over HTTP  设置为  Always allowed 
 
仅开发调试使用，正式发布项目建议采用HTTPS。
 
3. 运行Unity测试
将  GameApp.cs  挂载场景中任意GameObject。
调用  EnterGame()  方法，即可一次性执行4组网络请求。
在Console窗口查看请求日志。
Node终端会打印客户端上传的Query参数。
 
📝 接口说明
 
1. GET 自定义业务接口
 
地址： http://127.0.0.1:6080/uploadData?uname=jay&upwd=123456 
 
- 后端： req.query  获取URL后的参数
- 返回字符串： WebRequest! 
 
2. 静态资源访问
 
plaintext
  
http://127.0.0.1:6080/Version.txt
http://127.0.0.1:6080/Photo/laoda.png
 
 
文件存放于  www_root ，新增资源直接放入文件夹即可。
 
⚠️ 注意事项
 
1. 修改  main.js  代码后，需要 Ctrl + C 停止服务，重新执行启动命令才能生效。
2. 端口占用：启动报错  EADDRINUSE ，更换监听端口，同时同步修改Unity脚本内全部URL。
3. 当前示例缺少异常捕获与资源释放，仅用于学习演示。
4.  Application.persistentDataPath  为Unity持久化路径，各操作系统路径不同。
 
📌 后续拓展计划
 
- 增加POST‑JSON请求示例
- 添加请求失败、超时异常处理
- 请求完成后调用  Dispose()  释放网络对象
- 实现简单资源热更新逻辑
