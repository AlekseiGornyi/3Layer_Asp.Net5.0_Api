# 3Layer_Asp.Net5.0_Api
An educational ASP.NEt 5.0 API with a 3 layer architecture.
A database later was constructed with MySQL.

DAL
The DAL layer provides connection to our DB. Any other Layers would only reference to DAL layer.
All files conserning DB build is located in DAL/DataContext.
  In AppConfiguration we initiate ConfigurationBuilder and adding configure location of ConnectionString.
  in DatabaseContext we are mapping all out Entities classes fields to out DB tables, as their names possibly could differ from each other. 
Also we are describing DB Enteties connection relations at the end of each section.
  In DatabaseContextFactory we are preparing connection of out project into SQL DB.
Also we have to add our ConnectionString into appsettings.json file. ANd we have to add reference of DAL project(layer) to WEB_API.
After that if you have already created SQL DB you will be able to initiate migration. And create data tables inside your SQL DB.

The Enteties will all our tables fields description. If you want to make changes in any of Enteties classes fields, add, remove, change name or something. 
You will have to provide this changes into DataBaseContext file, to map updated Enteties to DB tables.

Funtions, in this folder we have CRUD file and ICRUD Interface file. In this files we describe generic methods that we are going to use in further.
Created methods privide Create, Read, Update and Delete mechanics for our DB. 
Inside ICRUD intefrace file we initiate all our methods so we could use them later.

LOGIC
The LOGIC or BL (Business Logic) layer is created to describe and provide all possible exhanges, updates and work with our data.
This layer is refer to DAL layer as it has to work with it, instead of making direct calls into our DB.
On this layer we have Implementation folder with the logic description of all our methods according to each Entity class.
An Intefraces folder with initiation of all service methods. 
And Models folder with all description of how our data should looks like. So all further actions with DB tables would be possible to act.
Also in StandardResultObject file we provide description of userMessage, if method succided and exeption in pair with internal message if we have an error.
Last 2 fields are neede to provide logging of and errors.
The Logic layer wotks calls DAL and provide data to API layer.
So we have an implementation of data incapsulation and data security.

API layer is a layer that refer to DAL and Logic layer. Calls Logic layer to provide data to work with and all possible operational methods.
Inside API layer we have Controllers folder will all our controllers.
And Models folder with files of entities class fields description for creation and update of a DB tables records.
