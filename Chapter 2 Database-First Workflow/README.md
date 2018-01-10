
<h1>Database-First workflow</h1>

<h2>Add existing database</h2>

<p>If we have a database we can easily import the script to Microsoft SQL Server Management Studio. First we find the script we open it in our Server Management Studio and then as shown in <strong>import_script.jpg</strong></p>

<p>Then we add the database to our project. To do that we need to follow the steps below.</p>

<ul>
  <li>First we add a new Entity model</li>
  <li>Then a New Connection with correct credentials and database</li>
  <li>Rename Connection Settings</li>
  <li>If we have installed Entiy framework from nuget package we won't have to choose Entity Framework version as shown in <strong>entity_framework_version.jpg</strong></li>
  <li>Tick tables so we can have them in our model</li>
  <li>We can let entity framework to singularize or pluralize the table names if the option clicked</li>
  <li>Finally we will get our model as shown in <strong>edmx.jpg</strong></li>

</ul>

<h3>EDMX</h3>

<ul>
  <li>You can zoom in by Ctrl+Mouse wheel</li>
  <li>You can drag and drop entities to look the way you want</li>
  <li>If it's messy you can have visual studio fix it with layout diagram as shown in layout_diagram.jpg</li>
  <li>We can also export it as image and collapse/expand all these entities in same window</li>
  <li>Another useful feature is to have display Name and Type as shown in <strong>display_name_and_type.jpg</strong></li>
  <li>Since Entity Framework tried to singularize the  names of our tables sometimes it fails like shown in  <strong>failed_singular.jpg</strong> which cut e and s. To fix this right click in the entity then properties and change its name. We have to be careful with these changes since if we refer to them somewhere with coded we might also need to make changes </li>
  <li>In each enity we have two sections. One is its properties and the other is Navigation Properties Navigation property is a property that helps you navigate from one entity to another entity as shown in <strong>navigation_properties.jpg</strong></li>
</ul>


<h3>EDMX under the hood</h3>

<p>EDMX is a visaul represantation for an XML. To see that XML we must first close the designer diagram. Then we right click in our edmx file and choose Open with XML editor as shown in <strong>XML_editor.jpg</strong>. The designer section includes data about the visual represantation of this EDMX. Any visually changes we make are represented in Designer. </p>

<p>The runtime section includes everything about our model.
We have 3 subsections. Storage models which is the representation of our database. Conceptual model which is the representation of our entities. Mapping which is the mapping between these two models.
</p>

<p>As we see in Storage model we have all info about the database, tables, properties etc.</p>

<p>In our ConceptualModel we have our entities. Their names, properties, types etc. ConceptualModel is very close to storage/database model.</p>

<p>Mapping model is the connection between Storage and Conceptual models. As we see in <strong>mapping.jpg</strong> we can see clearly the relation created between columns and properties. We can change our Conceptual model and mapping model will make sure that is persisted with storage model.</p>

<p>In our designer we purely see the enities. Not the storage model or the mapping. To see the mapping we right click in the entity as shown in <strong>table_mapping.jpg</strong>. We can do anything we want in our mapping like deleting a property or changing the mapping by right clicking. We might have a property that calcualtes something and we don;t want it into entity framework.</p>

<p>For our storage model visual represantation we right click in the empty space as shown in <strong>storage_model_visual_represantation.jpg </strong>. It's exactly the represantation we saw in our XML.</p>


<h4>Connection string</h4>

<p>Our connection strings can be found in App.config or for a web app in Web.config. Check <strong>conenction_strings.jpg</strong>. We have 3 resources seperated with | . After we cave connection string with the data source which shows the SQL instance we are using. Initial catalog the database name. Integrated security means we are using Windows authentication. In Database First the metadata created is a little confusing. When we compile our application Visual studio takes that XML breaks it into three parts and stores them as embedded resources in our assembly. So this metadata represents our Conceptual model, storage model and mapping model.</p>


<h2>Database first</h2>

<p>In database first we make changes first to our database and then we refresh our model.</p>

<h3>Add new table</h3>

<p><strong>add_new_table.jpg</strong>. Then we save our table. After that as <strong>shown in update_model_from_database.jpg</strong> we update our model. The Add tab shows stuff that we don't have in our entity model . The refresh tab shows what will be refreshed when we click finish. We click finsih and the table is added.</p>

<h3>Update a table</h3>

<h4>Add a column</h4>

<p>Just click at a row and add its name and type. Save it. </p>

<h4>Modify/delete a column</h4>

<p>Choose the table and click design to see all columns. Just make the changes you want or delete the columnd that isn't needed anymore. You also have to enable changes as show in <strong>enable_changes_to_tables.jpg</strong>. Update the model from database. We will get errors that warns us that the changes we made are not mapped. If it doesn't pops up you can right click in empty area in our model and select validate. </p>

<p>Entity framework doesn't see it if we rename something it sees that as a new column. So you have to delete the existing property that stayed there. Even if we change a type in database while it knows that in database is the new type it won't be changed in our model and we will have a validation error. You should change it manually in its properties window.</p>

<p>Entity framework also will not see if you deleted a column and you will have to do it manually. Validate and check if everything is good.</p>

<p>Adding columns works with no problems.</p>

<h3>Delete table</h3>

<p>If we delete something in management studio after we update model in visual studio we will see it appear in Delete tab. We will see an error so we have to remove it manually from our model.</p>

<h3>Stored procedures</h3>

<p>You can add them similarly by clicking in empty space Update Model from Database and then you will get <strong>stored_procedures.jpg</strong>.We have an option at the end that says Import selected stored rpocedures and functions into the entity model. With that clicked not only we nring these stored procedures and functions into our storage model but it will also create functions in our conceptual model that we can call to execute those procedures.</p>

<p>As shown in <strong>stored_procedures_into_model.jpg</strong> we see that we have these functions also in Function Imports and not only in our storage model. These functions or methods are available in our DbContext.Don't forget to save the model for every update. We have them now in Context class which derives from DbContext as you can see in DatabaseFirstProject. DbContext is one of the classes entity model creates so we have access to our database.</p>

<h4>Function imports</h4>

<p>Double click the function you want <strong>function_imports.jpg</strong>. You can change the name of the function if you see a strange/legacy name. In the picture you see the return type of the method.</p>

<ul>
<li>None - is for void methods that don't return anything</li>
<li>Scalars - return scalar characters like int string etc</li>
<li>Complex - it's a complex dump data structure that does not support change tracking.When we change the state of these objects the changes aren't going to be reflected in our database when we save them. The complex types are show in your conceptual model in the folder Complex types. You only have to use a complex type when a stroed procedure joins two or more tables. Another use is when you have really large entities with many properties. To create one you choose Complex then Get Column Information and click Create New Complex Type</li>
<li>Entities -  these are the classes we have in our entity data model</li>

</ul>

<p>So if we change the return type it is changed but it still remains in our conceptual model. We will have to delete the complex type manually.</p>

<h4>Creating an enum as a type</h4>

<h5>The first way is at our model as shown in <strong>create_enum.jpg</strong></h5>

<p>You can have a mixed type enum which it can have more than one values by clicking <strong>mixed_type_enum.jpg</stong></p>

<p>After we change the type to the newly created enum in properties of the model we will get an error for mapping.  We have to change the type to our database also. Validate so we have no errors. With the enum created we can have cleaner code.</p>

<h5>The second way is to import an already created enum</h5>

<p>First we create the enum normally in Visual studio.</p>
<pre>
[public enum Level:byte
{
  Beginner = 1,
  Intermediate = 2,
  Advanced = 3
}

</pre>
<p>Then in our model in Enum Types we need to create a new enum. The name and type of this enum must be exactly like the one we already have. So we reference this external in the option at the end Reference external type. We specify the strongly typed name for this enum. So namespace and name.Finally we change the datatype of this property in properties and set it to name of enum.</p>
