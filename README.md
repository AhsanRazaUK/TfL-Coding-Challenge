# TFL Coding Challenge

### To use this repository
```
git clone https://github.com/AhsanRazaUK/TfL-Coding-Challenge TfL-Coding-Challenge
cd TfL-Coding-Challenge
```
### To run the application

* Please open the following folder
```
[Drive or path where repository is clonsed]/TfL-Coding-Challenge/Road-Status-Alerter/RoadStatus/bin/Debug/netcoreapp3.0
```
* Open settings file in notepad ```appsettings.json```
* Provide your AppID and APIKey for TFL API or get new from ``` https://api-portal.tfl.gov.uk ```
* Open command prompt for this same folder and enter command with valid road name to get road status ``` C:\ .\RoadStatus A3 ``` 
* In case of invalid road name error message will appear
* To check the last error code ``` C:\ echo %ERRORLEVEL% ```

### To open the project

* Please open the following the solution in Visual Studio ``` Road-Status-Alerter.sln ``` 

## Authors

* **<a href='https://ahsanshares.wordpress.com/'>Ahsan Raza</a>** 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
