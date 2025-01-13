using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaApi.Controllers
{
    [Route("api/VillaAPI")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ApplicatonDbcontext _applicatonDbcontext;

        public VillaAPIController(ApplicatonDbcontext applicatonDbcontext)
        {
            _applicatonDbcontext = applicatonDbcontext;
        }

        //private readonly ILogger<VillaAPIController> _logger;
        //everything will takecare by DI
        //public VillaAPIController(ILogger<VillaAPIController> logger)
        //{
        //    _logger = logger;
        //}

        //private readonly ILogging _logger;
        //public VillaAPIController(ILogging logger)
        //{
        //    _logger = logger;   
        //}

        [HttpGet("GetAllVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //_logger.Log("Retrive the all Villas information", "");
            //return Ok(VillaStore.villaList);
            //setting from the local DB
            //_applicatonDbcontext.SavingChanges() to save the changes to DB
            return Ok(_applicatonDbcontext.Villas.ToList());
        }

        [HttpGet("GetVillasBy" + "{id:int}", Name = "GetVilla")]
        //[ProducesResponseType(200, Type = typeof(VillaDTO))]
        //if in the action result if it has a type then no longer needed in the response typeof

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                //logger.LogWarning("Get error with id" + id);
                return BadRequest();
            }
            var villa = _applicatonDbcontext.Villas.FirstOrDefault(x => x.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost("CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState)
            //}

            if (_applicatonDbcontext.Villas.FirstOrDefault(x => x.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa Already exist");
                return BadRequest(ModelState);
            }

            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }

            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa model = new Villa()
            {
                Id  = villaDTO.Id,
                Name = villaDTO.Name!,
                Sqft  = villaDTO.Sqft,
                Occupency  = villaDTO.Occupency,
     };
            //villaDTO.Id = _applicatonDbcontext.Villas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            _applicatonDbcontext.Villas.Add(model);
            _applicatonDbcontext.SaveChanges();
            //return Ok(villaDTO);
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }

        [HttpDelete("DeleteVilla" + "{id:int}", Name = "DeleteVilla")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _applicatonDbcontext.Villas.FirstOrDefault(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _applicatonDbcontext.Villas.Remove(villa);
            return NoContent();
        }

        [HttpPut("UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }

            Villa model = new Villa()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name!,
                Sqft = villaDTO.Sqft,
                Occupency = villaDTO.Occupency,
            };
            _applicatonDbcontext.Villas.Update(model);
            _applicatonDbcontext.SaveChanges(); 
            //var villa = _applicatonDbcontext.Villas.FirstOrDefault(x => x.Id == id);
            //villa.Name = villaDTO.Name;
            //villa.Sqft = villaDTO.sqft;
            //villa.Occupency = villaDTO.occupency;

            return NoContent();
        }

        [HttpPatch("UpdateByID/{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var villa = _applicatonDbcontext.Villas.FirstOrDefault(x => x.Id == id);

            VillaDTO villaDTO = new VillaDTO()
            {
                Name = villa.Name,
                Sqft = villa.Sqft,
                Occupency = villa.Occupency,
                ImageUrl = villa.ImageUrl, 
               
            };
            if (villa == null)
            {
                return BadRequest();
            }

            Villa Model = new Villa()
            {
                Name = villaDTO.Name,
                Sqft = villaDTO.Sqft,
                Id = villaDTO.Id,
                Description = villa.Description,
                Occupency = villa.Occupency,
                Rate = villa.Rate,
            };
            _applicatonDbcontext.Update(Model);
            _applicatonDbcontext.SaveChanges();

            patchDto.ApplyTo(villaDTO, ModelState);
            if (ModelState.IsValid)
            {
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        //[HttpPatch("UpdateByIDs/{id:int}", Name = "UpdatePartialVillas")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdatePartialVillas(int id, JsonPatchDocument<VillaDTO> patchDto)
        //{
        //    if (patchDto == null || id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);

        //    if(villa == null)
        //    {
        //        return BadRequest();
        //    }

        //    patchDto.ApplyTo(villa, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return NoContent();
        //}

    }
}
