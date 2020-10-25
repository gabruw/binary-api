using System;
using System.Collections.Generic;
using Api.Utils;
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
        private StoreValues _store = StoreValues.GetInstance();
        private readonly IDiffLeftRepository _diffLeftRepository;
        private readonly IDiffRightRepository _diffRightRepository;

        public DiffController(IDiffLeftRepository diffLeftRepository, IDiffRightRepository diffRightRepository)
        {
            _diffLeftRepository = diffLeftRepository;
            _diffRightRepository = diffRightRepository;
        }

        [HttpGet]
        public IActionResult StoreResult()
        {
            try
            {
                List<string> errors = new List<string>();

                if (_store.Left == null)
                {
                    errors.Add("O valor 'left' não pode ser nulo.");
                }

                if (_store.Right == null)
                {
                    errors.Add("O valor 'right' não pode ser nulo.");
                }

                if (errors.Count > 0)
                {
                    return BadRequest(ResponseFactory.GetResponse(errors));
                }
                else
                {
                    return Ok(ResponseFactory.GetResponse(_store.Left, _store.Right));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
                    return BadRequest(ResponseFactory.GetResponse(diffLeft.GetValidationMessage));
                }

                _store.Left = diffLeft;
                _diffLeftRepository.Incluid(diffLeft);

                return Ok(ResponseFactory.GetResponse(diffLeft.GetValidationMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
                    return BadRequest(ResponseFactory.GetResponse(diffRight.GetValidationMessage));
                }

                _store.Right = diffRight;
                _diffRightRepository.Incluid(diffRight);

                return Ok(ResponseFactory.GetResponse(diffRight.GetValidationMessage));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("db")]
        public IActionResult DbResult([FromQuery] long leftId, [FromQuery] long rightId)
        {
            try
            {
                DiffLeft diffLeft = _diffLeftRepository.GetbyId(leftId);
                DiffRight diffRight = _diffRightRepository.GetbyId(rightId);

                return Ok(ResponseFactory.GetResponse(diffLeft, diffRight));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("db/left")]
        public IActionResult DbRemoveLeft([FromQuery] long id)
        {
            try
            {
                DiffLeft diffLeft = _diffLeftRepository.GetbyId(id);
                _diffLeftRepository.Remove(diffLeft);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("db/right")]
        public IActionResult DbRemoveRight([FromQuery] long id)
        {
            try
            {
                DiffRight diffRight = _diffRightRepository.GetbyId(id);
                _diffRightRepository.Remove(diffRight);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
