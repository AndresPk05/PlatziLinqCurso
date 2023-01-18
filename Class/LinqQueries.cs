namespace Platzi_Net.Class
{
    public class LinqQueries
    {
        private IEnumerable<BookJSon> libros {get;set;}
        public LinqQueries()
        {
            using(var reader = new StreamReader("books.json")){
                var json = reader.ReadToEnd();
                libros = System.Text.Json.JsonSerializer.Deserialize<List<BookJSon>>(json, new System.Text.Json.JsonSerializerOptions{
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        public IEnumerable<BookJSon> GetAllBooks(){
            return libros;
        }

        public IEnumerable<BookJSon> GetBooksWithPublishedDateMayor2000(){
            //extensions Methods
            //var result = libros.Where(x=> x.PublishedDate.Year > 2000);

            //query expression
            var result = from l in libros
                            where l.PublishedDate.Year > 2000
                            select l;
            return result;
        }

        public IEnumerable<BookJSon> GetBooksWithMore250PagesAndTitleAction(){
            //query with extensions methods
            //var result = libros.Where(x=> x.PageCount > 250 && x.Title.ToUpper().Contains("ACTION"));

            //query expression
            var result = from l in libros 
                            where l.PageCount > 250 
                            && l.Title.ToUpper().Contains("ACTION") 
                            select l;
            return result;
        }

        public bool AllBooksExistsWithStatus(){
            //Extensions Methods
            var query = libros.All(x=> !string.IsNullOrEmpty(x.Status));            

            return query;
        }

        public bool ExistsBookWithPublishDate2005(){
            var result = libros.Any(x => x.PublishedDate.Year == 2005);
            return result;
        }

        public IEnumerable<BookJSon> GetAllBooksWithCategoriesPython(){
            //Extesions Methods
            //var query = libros.Where(x=> x.Categories.Contains("Python"));

            //Query Expressions
            var query = from l in libros where l.Categories.Contains("Python") select l;
            return query;
        }

        public IEnumerable<BookJSon> GetBooksWithCategorieJavaAndOrderName(){
            //Extensions Methods
            //var query = libros.Where(x=> x.Categories.Contains("Java")).OrderBy(c=> c.Title);

            //Query Expressions
            var query = from l in libros 
                        where l.Categories.Contains("Java")
                        orderby l.Title  
                        select l;
                        
            return query;
        }

        public IEnumerable<BookJSon> GetBookWithMore450PagesOrderByDescending(){
            //Extensions Methods
            //var query = libros.Where(x=> x.PageCount > 450).OrderByDescending(x=> x.PageCount);

            //Query Expression
            var query = from l in libros
                        where l.PageCount > 450
                        orderby l.PageCount descending
                        select l;


            return query;
        }

        public IEnumerable<BookJSon> GetFirstTreeBooksWithCategorieJava(){
            
            //Extensions Methods
/*             var query = libros
                            .Where(x=> x.Categories.Contains("Java"))
                            .OrderByDescending(x=> x.PublishedDate)
                            .Take(3); */

            //query Expressions
            var query = (from l in libros
                        where l.Categories.Contains("Java")
                        orderby l.PublishedDate descending
                        select l).Take(3);
                        
            return query;
        }

        public IEnumerable<BookJSon> GetThridFourBookMore400Page(){
            var query = libros
                            .Where(x=> x.PageCount > 400)
                            .Skip(2)
                            .Take(2);

            return query;
        }

        public IEnumerable<BookJSon> GetFirtsThridBooksTitlePageCount(){
            var query = libros
                        .Take(3)
                        .Select(x=> new BookJSon{
                Title = x.Title,
                PageCount = x.PageCount
            });

            return query;
        }

        public int CountBooksPages200to500(){
            var query = libros
                            .Count(x=> x.PageCount >= 200 && x.PageCount <= 500);

            return query;
        }

        public DateTime GethMinPublishDate(){
            var query =  libros.Min(x=> x.PublishedDate);
            return query;
        }

        public int GetMaxPageCount(){
            var query = libros.Max(x=> x.PageCount);
            return query;
        }

        public decimal GetCountBookWithPage0to500(){
            var query = libros
                            .Where(x=> x.PageCount >= 0 && x.PageCount <= 500)
                            .Sum(x=> x.PageCount);
            
            return query;
        }

        public string GetTitlesForBooksWithPublishedDateMayor2015(){
            var query = libros
            .Where(x=> x.PublishedDate.Year > 2015)
            .Aggregate("", (Titulos, next) => Titulos += Titulos != string.Empty ? $" - {next.Title}" : next.Title);

            return query;
        }

        public IEnumerable<IGrouping<int, BookJSon>> GetBookPublibihsDate2000GroubyYear(){
            var query = libros
                            .Where(x=> x.PublishedDate.Year >= 2000)
                            .GroupBy(x=> x.PublishedDate.Year);

            return query;

        }
    }
}