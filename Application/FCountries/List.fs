namespace FCountries
open MediatR
open Domain
open Microsoft.Extensions.Logging
open Persistence
open System.Threading
open Microsoft.EntityFrameworkCore
open System.Collections.Generic

module john = 
    let square x = x * x

module CountryRequest = 
    
    type Querys(id: System.Guid) =

        //member val Id : System.Guid = id  with get, set

        class
            member val Id : System.Guid = id  with get, set
            interface IRequest<List<Country>>
        end      

    type Handlers(context: DataContext) = 
        interface IRequestHandler<Querys, List<Country>> with 
            member this.Handle(request: Querys, ct: CancellationToken ) = 
                let countries = task {
                    return! context.Countries.ToListAsync() 
                }
                countries
            
    type ListCountry(context: DataContext) = 

        let query = new Querys(System.Guid.NewGuid())
        let handler = new Handlers(context)


// https://fsharpforfunandprofit.com/posts/dependency-injection-1/

