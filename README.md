# MovieCatalogueAppWithMVC
This is a movie Catalogue Application with MVC.
To use this application effectively some interesting steps are required:
Firstly:
You"ll need to edit the Connection string located in the appsettings.json file to fit your server name, for mac users the user id and password of your server is required "ConnectionString": {
    "DefaultConn": "Data Source=localhost,1433;Initial Catalog=MovieDB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
}
After you've created your database successfully, you can access some of our features
Let's Roll
This application implements features for users and admin
The users role contains features like:
viewing the list of our available movies 
visiting the imdb site to check out the trailer of the movie 

For the admin role:
A login is required 
UserName: LynnBaby
Password: LynnBaby@1
I have implemented the CRUD operations
Admin can create a new movie: during this process copy an imdb link for the movie from the imdb site
and for the poster,  copy the image url in this format(Advengers EndGame Thumbnail)
Admin can also edit and delete movies

Hope this was helpful

Note: This application open for modification
