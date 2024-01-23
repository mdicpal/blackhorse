namespace Orchestrator.Database.Repositories;

using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InstanceToPollRepository : IInstanceToPollRepository
{
    private readonly DatabaseContext _context;
    private readonly ILogger<InstanceToPollRepository> _logger;
    private readonly IMapper _mapper;

    public InstanceToPollRepository(DatabaseContext context, ILogger<InstanceToPollRepository> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
        
    public async Task<List<InstanceToPollDto>> GetAllAsync()
    {
        List<InstanceToPoll> instances = await _context.InstancesToPoll.ToListAsync();
        List<InstanceToPollDto> instancesToPoll = _mapper.Map<List<InstanceToPollDto>>(instances);
        return instancesToPoll;
    }
        
    private async Task<InstanceToPoll> GetInstanceToPollByApplicationIdAsync(string applicationId)
    {
        return await _context.InstancesToPoll.FirstOrDefaultAsync(x => x.ApplicationId == applicationId);
    }

    public async Task<bool> UpsertAsync(InstanceToPollDto instanceDto)
    {
        try
        {
            InstanceToPoll instance = await GetInstanceToPollByApplicationIdAsync(instanceDto.ApplicationId);
            if (instance is null)
            {
                await InsertInstance(instanceDto);
            }
            else
            {
                await UpdateInstance(instance, instanceDto);
            }

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to upsert to database");
            return false;
        }
    }

    private async Task InsertInstance(InstanceToPollDto instanceDto)
    {
        InstanceToPoll instance = _mapper.Map<InstanceToPoll>(instanceDto);
        _context.InstancesToPoll.Add(instance);
        await _context.SaveChangesAsync();
    }

    private async Task UpdateInstance(InstanceToPoll instance, InstanceToPollDto instanceDto)
    {
        _mapper.Map(instanceDto, instance);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(string applicationId)
    {
        try
        {
            var instance = await GetInstanceToPollByApplicationIdAsync(applicationId);

            if (instance is not null)
            {
                _context.InstancesToPoll.Remove(instance);
                await _context.SaveChangesAsync();

                return true;
            }
            _logger.LogWarning("Attempted to delete non-existent InstanceToPoll for applicationId {ApplicationId}", applicationId);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error when attempting to delete InstanceToPoll for {ApplicationId}", applicationId);
            return false;
        }
    }
}