# ControlodeContactos

-> Vou criar um sistema de login


-----------------------------------------------------------------------------------------------------------

Passos Para a criação da ligação entre o SQL E VISUAL STUDIO 2022 ( NET 7)

1 -> 1ª coisa a fazer é dentro da pasta Models, criar umo modelo contacto neste em outra projeto é outro modelo. Depois dentro da classe ContactoModel é criar os atributos

2 -> Agora criar uma pasta com nome "Data" que é o que vai receber as conexões e configurações

3 -> Estando agora dentro da pasta "Data" vamos criar uma classe de nome "BDContext"

4 -> Depois de criada a classe BDContext vamos instalar Pacotes através do Manager NUGET pakage

5 -> Na janela que abriu, escolher onde diz Browse e depois no local da pesquisa, procurar por "Microsoft.EntityFrameworkCore" e escolher na direita e selecionar o projeto e instalar com a mesma versão do projeto criado. No meu caso foi .net 7 logo tenho de instalar no máximo a versão 7.0.17

6 -> Instalar também estes 3 pacotes: 
"Microsoft.EntityFrameworkCore.Design",
"Microsoft.EntityFrameworkCore.Tools",
"Microsoft.EntityFrameworkCore.SQLServer"

7 -> Agora ir novamente a classe DBContext, escrever a frente do PUBLIC CLASS DBContext : "DbContext".

8 -> Ainda no ficheiro classe DBContext, 
public class BDContext : DbContext
{
    public BDContext(DbContextOptions<BDContext> options) : base(options)
    {
    }
}

9 -> Nesta parte ainda no ficheiro class DBContext adicionar fora desta parte anterior os nomes das tabelas que vamos criar no SQL Server.

 public DbSet<ContactoModel> Contactos { get; set; }

Ficando então assim:  

public class BDContext : DbContext
 {
     public BDContext(DbContextOptions<BDContext> options) : base(options)
     {
     }
     public DbSet<ContactoModel> Contactos { get; set; }
 }

10 -> Agora é preciso ir ao ficheiro de Program.cs que é o ficheiro que arranca com o sistema. E adicionar isto aqui o que está dentro de parentesis:

// Add services to the container.
builder.Services.AddControllersWithViews();
"builder.Services.AddDbContext<BDContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); "


11 -> Agora indo ao appsettings.json, vamos adicionar isto: 

//DefaultConnection pode ser outro nome a escolha.
"ConnectionStrings": {
  "DefaultConnection": "server=DESKTOP-5AD92J0\\SQLEXPRESS; Database=DB_SistemaContactos; Trusted_connection=true; TrustServerCertificate=True"
}

12 -> Para finalizar e usar o Migration: ir onde diz TOOLS > NUGET PACKAGE MANAGER > PACKAGE MANAGER CONSOLE

Agora neste ponto apenas precisamos de escrever: 
"Type 'get-help NuGet' to see all available NuGet commands.

PM> ADD-MIGRATION CriarTabelaContactos -Context BDContext" -> Aqui é onde escolhemos o nome para a Migração

Depois carregar em ENTER

Agora verificar se o Mapeamento que escolhemos é este. 

De seguida, voltar a escrever: 
"PM> update-database -Context (BDContext)" DBContext foi o nome que foi dado na classe que está em Dados.

Agora é só carregar em ENTER e feito o Update

-----------------------------------------------------------------------------------------------------------
