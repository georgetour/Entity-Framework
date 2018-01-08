
<h1>Entity Framework</h1>

<p>To use a database we need a persistence framework. You are able to load objects from or save them to a database. It is possible to create something like that custom so we can connect with the database but it would take a log time. </p>

<p>This is where Entity framework shines. You <strong>no longer</strong> have to write
<ul>
<li>Stored procedures</li>
<li>Manage Database Connections</li>
<li>Manually Mapping </li>
</ul>

</p>
<p>Entity framework handles all the dirty work for us. The amazing thing with Entity is that you use objects to do stuff with the database. </p>

<section>
<h2>Workflows</h2>

<p>You can check the video Workflows.wmv from microsoft. We have three workflows to build models according to our needs.</p>


<h3>Database First</h3>
<ul>
<li>We design our tables</li>
<li>Entity framework generates domain classes</li>
</ul>
<p>Check project Database-First-Workflow</p>

<h3>Code First</h3>
<ul>
<li>Create domain classes</li>
<li>Entity framework generates database tables</li>
</ul>

<h3>Model First</h3>
<ul>
<li>Use Visual designer to model our classes and associations</li>
<li>UML diagram</li>
<li>Based on the diagram Entity framework will create the database and tables</li>
</ul>
<p>This approach isn't used.</p>

</section>

<section>

<h4>Installation and Database first approach</h4>
<p>To create a database you can use either Microsoft SQL server management studio or from Visual Studio. You go to Object Explorer as shown in <strong>object_explorer.jpg</strong> and then you create a database as in <strong>new_database.jpg </strong>.Similarly you create tables etc.</p>

<p>To use Entity framework we have to install it from Nuget Package Manager as shown <strong>entity-installation.jpg</strong>. Then at Package Manager Console we write : <br> install-package EntityFramework</p>

<h5>Importing existing Database to project and Connecting to database</h5>

<p>After that we go to Solution Explorer and we add a New Item ADO.NET Entity Data Model which will represent the mapping between the database tables and our domain classes. If you already have a database you choose <strong>EF Designer from Database</strong>. Then at New Connection Microsoft SQL Server. </p>

<p>To connect to the database we need server name, database name and credentials as shown in <strong>connect_to_database.jpg</strong>.Test connection to see if everything works fine. Now entity frameworks looks at our database and discovers the table views and stored procedures as shown in <strong>ef_mappiong_ready.jpg</strong></p>

<h4>Entity Data Model edmx</h4>

<p>Edmx is our data model that is created by entity framework so we can use it as shown in <strong>edmx.jpg</strong>. When expanding the edmx file we will see a tt extension which stands for T for template. It's a way to generate code based on a template. If we expand this we ll see the actual generated code as shown in <strong>edmx_exapnded.jpg</strong>.
It provides a simple API to load data or save it to the database.</p>

<p>We have properties created according to tables as shown in <strong>edmx_property.jpg</strong> which derive from DbContext.</p>

<h5>NameModel.tt</h5>

<p>We also have a class with properties according to tables created as shown in <strong>edmx_class_according_to_table.jpg</strong> with properties based on columns.</p>



<p>With database first approach everytime we want to make a change to my model we start from the database and then come back to edmx file and refresh it.</p>

</section>

<section>
<h3>DB context</h3>

<p>This applies to both Database first and Code first models. Create an instance which is the name of our project and the the end Entities. In our case the project is DatabaseFirstDemo so the cllass we need will be DatabaseFirstDemoEntities.
</p>
<pre>
var context = new DatabaseFirstDemoEntities();
</pre>
<h5>Creating new content for our table</h5>
<pre>
var post = new Post()
{
    Body = "Body",
    DatePublished = DateTime.Now,
    Title = "Title",
     PostID = 1
};
</pre>

<p>Then we add it to memory</p>
<pre>
context.Posts.Add(post);
</pre>

<p>Add post to db by saving changes</p>
<pre>
context.SaveChanges();
</pre>

<p>We didn't have to work with ADO.NET  classes like sequel connection and sequel commnd. Entiyty framework took care eveything</p>

<p>To verify eveything went smoothly go to Management Studio and check <strong>show_rows_from_table.jpg</strong>
</section>
