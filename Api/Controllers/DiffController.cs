using System;
using System.Collections.Generic;
using Api.Utils;
using Domain.DTO;
using Domain.Entity;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class DiffController : ControllerBase
    {
        private Storage _storage = Storage.GetInstance();
        private readonly IDiffLeftRepository _diffLeftRepository;
        private readonly IDiffRightRepository _diffRightRepository;

        public DiffController(IDiffLeftRepository diffLeftRepository, IDiffRightRepository diffRightRepository)
        {
            _diffLeftRepository = diffLeftRepository;
            _diffRightRepository = diffRightRepository;
        }

        [HttpGet]
        public IActionResult StorageResult()
        {
            try
            {
                Response response = Validate.VerifyDiff(_storage.Left, _storage.Right);

                if (response.Errors.Count > 0)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpPost("left")]
        public IActionResult Left([FromBody] DiffLeft diffLeft)
        {
            try
            {
                diffLeft.Validate();

                if (diffLeft.isValid)
                {
                    diffLeft = (DiffLeft)Binary.BinaryToString(diffLeft);
                }
                else
                {
                    return BadRequest(Validate.FormatObservationInclude(diffLeft));
                }

                _storage.Left = diffLeft;
                _diffLeftRepository.Incluid(diffLeft);

                return Ok(Validate.FormatObservationInclude(diffLeft));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpPost("right")]
        public IActionResult Right([FromBody] DiffRight diffRight)
        {
            try
            {
                diffRight.Validate();

                if (diffRight.isValid)
                {
                    diffRight = (DiffRight)Binary.BinaryToString(diffRight);
                }
                else
                {
                    return BadRequest(Validate.FormatObservationInclude(diffRight));
                }

                _storage.Right = diffRight;
                _diffRightRepository.Incluid(diffRight);

                return Ok(Validate.FormatObservationInclude(diffRight));

            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpGet("db")]
        public IActionResult DbResult([FromQuery] long leftId, [FromQuery] long rightId)
        {
            try
            {
                DiffLeft diffLeft = _diffLeftRepository.GetbyId(leftId);
                DiffRight diffRight = _diffRightRepository.GetbyId(rightId);

                return Ok(Validate.VerifyDiff(diffLeft, diffRight));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpGet("db/left")]
        public IActionResult DbGetAllLeft()
        {
            try
            {
                IEnumerable<DiffLeft> diffLeftList = _diffLeftRepository.GetAll();
                return Ok(diffLeftList);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpGet("db/right")]
        public IActionResult DbGetAllRight()
        {
            try
            {
                IEnumerable<DiffRight> diffRightList = _diffRightRepository.GetAll();
                return Ok(diffRightList);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpDelete("db/left")]
        public IActionResult DbRemoveLeft([FromQuery] long id)
        {
            try
            {
                DiffLeft diffLeft = _diffLeftRepository.GetbyId(id);
                _diffLeftRepository.Remove(diffLeft);

                return Ok(Validate.FormatObservationRemove(diffLeft));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }

        [HttpDelete("db/right")]
        public IActionResult DbRemoveRight([FromQuery] long id)
        {
            try
            {
                DiffRight diffRight = _diffRightRepository.GetbyId(id);
                _diffRightRepository.Remove(diffRight);

                return Ok(Validate.FormatObservationRemove(diffRight));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(Validate.FormatError(ex.ToString()));
            }
        }
    }
}
