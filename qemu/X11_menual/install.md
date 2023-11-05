## server linux guide

>1. sudo apt update
>2. sudo apt upgrade
>3. sudo apt install xauth
>4. sudo apt update
>5. sudo apt upgrade


## host vscode guide

>1. install vcxsrv ==> Display number=10 ==> Disable access control (checked) <br/>
>2. ssh setting <br/>
    Host MADLEN_LINUX <br/>
    HostName 192.168.0.2 <br/>
    User lsh <br/>
    IdentityFile ~/.ssh/madlen_linux <br/>
    ForwardX11 yes <br/>
    ForwardX11Trusted yes <br/>
>3. 시스템 환경변수 설정 <br/>
    DISPLAY<br/>
    localhost:10.0<br/>