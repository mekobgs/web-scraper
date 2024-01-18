# Web Scraper

This is going to be a simple application, where a user can add a link to a web page and
the application will scrape all the information of that page and get a list of all of the
links in that page. This will be stored in a Database and each user will be able to see the links scrapped.




## Features

- As a user, I must be able to register on the platform. For this, it will only be necessary to enter a username and password.

- As a user, I must be able to log into the system using an email and a password.

- As a user, I should be able to see a list of all the pages that I have scrapped with the number of links that the scraper found.

- As a user, I should be able to see the details of all the links of a particular page, that means the url of a link and the “name” of a link.

- As a user I should be able to add a url and the system should be able to check for all the links and add it to the database. A link will have the following format ```<a href="https://www.w3schools.com">``` Visit W3Schools.com! </a> the href will be the link and the body will be the name of the link. Keep in mind that the body of a link sometimes is not only text and could be other html elements, in those cases you could save only a  portion of the html. The title of the web page will be the page name. Keep in mind that some pages will take more time than others to scrape.

## Tools used

This project has built with:

- Net Core 7
- EntityFrameworkCore 7.0.14
- HtmlAgilityPack
- SQL Server
- XUnit
- Moq
    
Please review the appsettigns json and change the following fields:

``` "ConnectionStrings": {
    "DefaultConnection": "Server=YourServer;Database=WebScraper;User Id=YourUser;Password=YourPassword;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "YourLongAndSecurePrivateKey",
    "Issuer": "test.com",
    "Audience": "abc.com"
  },
  ```

Then run the migrations:

NetCoreCli ``` dotnet ef database update ``` or Visual Studio Package Manager Console ```Update-Database```

Now you can run the project and enjoy
## Authors

- Github: [@mekobgs](https://www.github.com/mekobgs)
- LinkedIn: [echacon-dev](https://www.linkedin.com/in/echacon-dev/)
- email: elmerster@gmail.com

