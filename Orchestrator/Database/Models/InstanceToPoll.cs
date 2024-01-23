namespace Orchestrator.Database.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(ApplicationId))]
public class InstanceToPoll
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    public int QuoteId { get; set; }
    public int CustomerId { get; set; }
    public int ProposalId { get; set; }
    public string ApplicationId { get; set; }
    
    public string InstanceId { get; set; }

    public string DeterministicHash { get; set; }
    
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}