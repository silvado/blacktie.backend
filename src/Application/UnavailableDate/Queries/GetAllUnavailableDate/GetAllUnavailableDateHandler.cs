using Application.Abstractions.Messaging;
using Application.Contracts.UnavailableDate;
using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Queries.GetAllUnavailableDate
{
    public class GetAllUnavailableDateHandler : IQueryHandler<GetAllUnavailableDateQuery, List<DateTime>?>
    {
        private readonly IUnavailableDateService _service;

        public GetAllUnavailableDateHandler(IUnavailableDateService service)
        {
            _service = service;
        }

        public async Task<List<DateTime>?> Handle(GetAllUnavailableDateQuery request, CancellationToken cancellationToken)
        {
            var filter = request.parameters.Adapt<UnavailableDateFilter>();

            filter.PageSize = 400;

            var lista = await _service.GetFilteredAsync(filter);

            if (lista == null)
                return null;

            var unavailableDates = lista.Data;


            if (unavailableDates == null)
                return null;

            List<DateTime> allDates = new List<DateTime>();

            foreach (var dateRange in unavailableDates)
            {
                if (dateRange.EndAt.HasValue && dateRange.EndAt > dateRange.StartAt)
                {
                    DateTime currentDate = dateRange.StartAt;
                    while (currentDate <= dateRange.EndAt.Value)
                    {
                        allDates.Add(currentDate.Date);
                        currentDate = currentDate.AddDays(1); // Avança para o próximo dia
                    }
                }
                else
                {
                    // Caso o EndAt seja null, adiciona apenas a StartAt como uma única data
                    allDates.Add(dateRange.StartAt.Date);
                }
            }

            return allDates.Distinct().ToList();
        }
    }
}
