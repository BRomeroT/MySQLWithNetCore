# Demo MySQL con NetCore

Basado en la [documentaci�n de MySQL Connector/Net](https://dev.mysql.com/doc/connector-net/en/connector-net-entity-framework.html)

Al momento de este demo usar el Scaffolding marca error, por lo tanto hay que hacer las entidades manualmente como indica en la [documentaci�n](https://dev.mysql.com/doc/connector-net/en/connector-net-entity-framework.html)

Solo hay que agregar el **MySql.Data.EntityFrameworkCore** si se agrega el *Microsoft.EntityFrameworkCore* causa erro en tiempo de ejecuci�n porque confunde el *Mapping* implementado en MySQLData con el de Microsoft.Entity

## Requerimientos
* Solo se puede conectar a MySQL 5.7 o superior
* Es necesario el MySQL Connector 6.10.5 o superior para poder usar NetCore 2.0
* MySQL Connector 8.0.12 no es compatible con Scaffolding
* Es m�s sencillo instalarlo con el [MySQL Installer](https://dev.mysql.com/downloads/installer/)


[M�s informaci�n...](https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html)

## Implementaci�n
* Crear un proyecto con NetCore 2.x
* Agregar la el NuGet package [*MySql.Data.EntityFrameworkCore*](https://www.nuget.org/packages/MySql.Data.EntityFrameworkCore/)
  > **Importante:** No agregar la referencia al NuGet package *Microsoft.EntityFrameworkCore* por problemas de compatibilidad
* Crear las clases *POCO* manualente, es decir el DataContext y las entidades de modelo
  * Herdar el *DataContext* de *DbContext* que se encuentra en Microsoft.EntityFrameworkCore
  * Agregar los *DBSets* de cada Tabla con las Entidades que describan su estructura:
    ```csharp
    using Microsoft.EntityFrameworkCore;
    namespace MySQLNetCore.Model
    {
        public class DemoDataContext : DbContext
        {
            public DbSet<Log> Logs { get; set; }
    ```
  * Sobreescribir el m�todo *OnConfiguring* del DataContext para indicar que use MySQL y agregar la cadena de conexi�n:
    ```csharp
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=P@ssw0rd;database=demobd");
    }
    ```
  * Sobreescribir el m�todo *OnModelCreating* para indicar las reglas de estructura y relaci�n entre las entidades:
    ```csharp
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
    ```