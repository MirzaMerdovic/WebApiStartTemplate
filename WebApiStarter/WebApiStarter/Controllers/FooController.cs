using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Examples;

namespace WebApiStarter.Controllers
{
    /// <summary>
    /// Represents test controller that should be removed.
    /// </summary>
    [RoutePrefix("api/foo")]

    public class FooController : ApiController
    {
        private readonly IFooService _service;

        public FooController(IFooService service)
        {
            _service = service;
        }

        /// <summary>
        /// Tries to create a new foo.
        /// </summary>
        /// <param name="foo">Instance of <see cref="Foo"/>.</param>
        /// <returns>Returns 201.</returns>
        [HttpPost, Route(""), ResponseType(typeof(Foo))]
        [SwaggerRequestExample(typeof(Foo), typeof(FooRequestExample))]
        [SwaggerResponseExample(HttpStatusCode.Created, typeof(FooResponseExample))]
        public async Task<IHttpActionResult> Post(Foo foo)
        {
            var newFoo = await _service.Add(foo).ConfigureAwait(false);

            return CreatedAtRoute("GetById", new { newFoo.Id }, newFoo);
        }

        /// <summary>
        /// Tries to retrieve all foo objects.
        /// </summary>
        /// <returns>200 with collection of foo objects.</returns>
        [HttpGet, Route(""), ResponseType(typeof(IEnumerable<Foo>))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(FooListResponseExample))]
        public async Task<IHttpActionResult> Get()
        {
            var foos = await _service.Get().ConfigureAwait(false);

            return Ok(foos);
        }

        /// <summary>
        /// Tries to retrieve specified foo.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>200, or 404 if the foo doesn't exist.</returns>
        [HttpGet, Route("{id:int}", Name = "GetById"), ResponseType(typeof(Foo))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(FooResponseExample))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var foo = await _service.Get(id).ConfigureAwait(false);

            if (foo == null)
                return NotFound();

            return Ok(foo);
        }

        /// <summary>
        /// Tries to update the foo object.
        /// </summary>
        /// <param name="foo">Instance of <see cref="Foo"/> that contains modified values.</param>
        /// <returns>200.</returns>
        [HttpPatch, Route("")]
        [SwaggerRequestExample(typeof(Foo), typeof(FooRequestExample))]
        public async Task<IHttpActionResult> Patch(Foo foo)
        {
            await _service.Update(foo).ConfigureAwait(false);

            return Ok();
        }

        /// <summary>
        /// Tries to delete the specified foo.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <returns>200.</returns>
        [HttpDelete, Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            // Delete should throw 404 if the resource doesn't exist, but it's skipped for brevity sake.
            await _service.Delete(id).ConfigureAwait(false);

            return Ok();
        }
    }

    #region Services

    public interface IFooService
    {
        Task<Foo> Add(Foo foo);

        Task<Foo> Get(int id);

        Task<IEnumerable<Foo>> Get();

        Task Update(Foo foo);

        Task Delete(int id);
    }

    public class FooService : IFooService
    {
        public Task<Foo> Add(Foo foo)
        {
            return Task.FromResult(new Foo { Id = new Random().Next(), Value = foo.Value });
        }

        public Task<Foo> Get(int id)
        {
            return Task.FromResult(new Foo { Id = id, Value = "Foo" });
        }

        public Task<IEnumerable<Foo>> Get()
        {
            return Task.FromResult<IEnumerable<Foo>>(new List<Foo>
            {
                new Foo {Id = 1, Value = "Foo"},
                new Foo {Id = 2, Value = "Boo"}
            });
        }

        public Task Update(Foo foo)
        {
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            return Task.CompletedTask;
        }
    }

    #endregion

    #region Contracts

    public class Foo
    {
        /// <summary>
        /// Gets the creation date.
        /// </summary>
        public DateTime CreatedAt => DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }
    }

    #endregion

    #region Swagger Examples

    public class FooRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Foo
            {
                Id = new Random().Next(),
                Value = Guid.NewGuid().ToString().Remove(6)
            };
        }
    }

    public class FooResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Foo
            {
                Id = new Random().Next(),
                Value = Guid.NewGuid().ToString().Remove(6)
            };
        }
    }

    public class FooListResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<Foo>
            {
                new Foo {Id = new Random().Next(), Value = Guid.NewGuid().ToString().Remove(6)},
                new Foo {Id = new Random().Next(), Value = Guid.NewGuid().ToString().Remove(6)}
            };
        }
    }

    #endregion
}