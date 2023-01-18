// See https://aka.ms/new-console-template for more information
using Platzi_Net.Class;

var linqQueries = new LinqQueries();

//Imprimir todos los libros de la coleccion
//ImprimirLibrosColeccion(linqQueries.GetAllBooks());

//Imprimir todo los libros con mas de 250 paginas y que el titulo contenga action
//ImprimirLibrosColeccion(linqQueries.GetBooksWithMore250PagesAndTitleAction());

//Imprimir si todos los libros tiene status
//System.Console.WriteLine($"Todos los libros tienen un status? R:/ {linqQueries.AllBooksExistsWithStatus()}");

//Imprimir si algun libro tiene fecha de publicacion del 2005
//System.Console.WriteLine($"Existe algun libro con fecha de publicacion del 2005? R:/ {linqQueries.ExistsBookWithPublishDate2005()}");

//Imprimir todas los libros que tengan la categoria Python
//ImprimirLibrosColeccion(linqQueries.GetAllBooksWithCategoriesPython());

//Imprimir todos los libros con categoria Java y order por nombre de manera ascendente
//ImprimirLibrosColeccion(linqQueries.GetBooksWithCategorieJavaAndOrderName());

//Imprimir todos los libros con mas de 450 paginas order by pageCoung desending
//ImprimirLibrosColeccion(linqQueries.GetBookWithMore450PagesOrderByDescending());

//Imprimir los tres primeros libros con categoria java y con la fecha de publicacion mas reciente
//ImprimirLibrosColeccion(linqQueries.GetFirstTreeBooksWithCategorieJava());

//Imprimir el libro res y cuatro de los que tienen mas de 400 paginas
//ImprimirLibrosColeccion(linqQueries.GetThridFourBookMore400Page());

//Imprimir los tres primeros libros de la coleccion con select
//ImprimirLibrosColeccion(linqQueries.GetFirtsThridBooksTitlePageCount());

//Imprimir cantidad de libros que tengan entre 200 y 500 paginas
//System.Console.WriteLine($"Cantidad de libros {linqQueries.CountBooksPages200to500()}");

//Imprimir la menor fecha de publicacion
//System.Console.WriteLine(linqQueries.GethMinPublishDate());

//Imprimir el mayor numero de paginas
//System.Console.WriteLine($"El mayor numero de paginas es: {linqQueries.GetMaxPageCount()}");

//Imprimir la suma de las paginas de los libros que tengan paginas entre 0 a 500
//System.Console.WriteLine($"Cantidad total de paginas: {linqQueries.GetCountBookWithPage0to500()}");

//Imprimir los titulos de los libros que tengan fecha de publicacion superior al 2015
System.Console.WriteLine($"Los titulos son:{linqQueries.GetTitlesForBooksWithPublishedDateMayor2015()}");

void ImprimirLibrosColeccion(IEnumerable<BookJSon> books){
    System.Console.WriteLine("{0, -60} {1, 16} {2, 11}", "Titulo", "N. Paginas", "Fecha Publicacion");

    foreach(var book in books){
        System.Console.WriteLine("{0, -60} {1, 16} {2, 11}", book.Title, book.PageCount, book.PublishedDate);
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,BookJSon>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}
