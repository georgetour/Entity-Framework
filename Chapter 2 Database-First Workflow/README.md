
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
