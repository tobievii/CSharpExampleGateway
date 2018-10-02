# IoT.nxt Example C# Gateway

An example of a gateway that connects to the IoT.nxt platform in C#.

How to : 

-----------------------------------------------
Pre-requisites 
*Git for windows and .net 4.7 or later 

*Understanding of c# code
-------------------------------------------------

We recommend you get git for windows to clone the repo 
https://git-scm.com/download/win 
Run the installer 

Get visual studio 2017 community it’s free
https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=15

----------------------------
Cloning the repo
----------------------------
Create a folder on your desktop called IoTnxt
Right click in the folder and click on open with Git bash 
Now type the following
git clone https://github.com/IoT-nxt/CSharpExampleGateway.git 

----------------------------------------
Open project in Visual Studio
----------------------------------------
In your cloned application folder 
Open the IoTnxt.Example.Gateway.sln file (solution file) with Visual Studio 
Now do a clean and build of the project 

-----------------------------------------
Gateway setup
-----------------------------------------
Open the file Program.cs
You can edit the gateway id for this device , we have added a generic one for you 
You can edit the Secretkey , it is your password . It should be strong and secure and never shared except during registration. It cannot be changed once you have registered the gateway.
------------------------------------------
Add packets or devices 
------------------------------------------
Open the file ExampleGateway.cs file 
In the RunAsync() method you can setup how your packets are sent to the platform 
You can also setup your sensors data and packet information. 

------------------------------------------
Register your gateway on portal
-------------------------------------------
Lets run the application and copy the autogenerated gateway id 
(If you changed the id , make sure that this prints the correct id) 
Open up https://portal.iotnxt.io/
Login and go to Entity Manager
On the right side of the screen is Gateways 
In the empty box paste in your gatewayed and associate your gateway 
Now you can start seeing your device data being consumed by the IoT.nxt solution 
Click on inspect to see all your packets being sent to the portal 

----------------------
THE END
----------------------

For more information on what now? See the videos in our youtube channel 
•	Creating endpoints and all the ETL wonders we have 
•	Creating a live dashboard and linking your data to show

See License.txt for license terms.
