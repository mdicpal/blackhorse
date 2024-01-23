namespace FunderService.Extensions;

using Mappers;
using FunderService.Mappers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class FunderMapperDependencyExtension
{
    internal static IServiceCollection AddFunderMapperDependencies(this IServiceCollection services)
    {
        services
         .AddSingleton<ICustomerMapper, CustomerMapper>()
         .AddSingleton<IAddressMapper, AddressMapper>()
         .AddSingleton<IIndividualMapper, IndividualMapper>()
         .AddSingleton<IEmployementMapper, EmployementMapper>()
         .AddSingleton<IMarketingMapper, MarketingMapper>()
         .AddSingleton<IProposalMapper, ProposalMapper>()
         .AddSingleton<IOrganisationMapper, OrganisationMapper>()
         .AddSingleton<IBankDetailsMapper, BankDetailsMapper>()
         .AddSingleton<IFinancialsMapper, FinancialsMapper>()
         .AddSingleton<IAffordabilityMapper, AffordabilityMapper>()
         .AddSingleton<IAddonsMapper, AddonsMapper>()
         .AddSingleton<IDepositMapper, DepositMapper>()
         .AddSingleton<IAssetMapper, AssetMapper>();
         
        return services;
    }
}