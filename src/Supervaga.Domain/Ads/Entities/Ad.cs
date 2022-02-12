using Supervaga.Domain.Shared.Contracts.Entities;
using Supervaga.Domain.Users;

namespace Supervaga.Domain.Ads
{
    public class Ad : Entity
    {
        public Ad()
        {
        }

        public Ad(
            string title,
            string category,
            string description,
            string address,
            string audienceGender,
            DateTime expiresAt,
            IList<Advantage> advantages,
            IList<Requirement> requirements,
            float? salaryOffer,
            bool isFreelance = false
        )
        {
            Title = title!;
            Category = category!;
            Description = description!;
            Address = address!;
            AudienceGender = audienceGender!;
            CreatedAt = DateTime.Now;
            ExpiresAt = expiresAt;
            IsFreelance = isFreelance;
            Advantages = advantages;
            Requirements = requirements!;
            SalaryOffer = salaryOffer;
        }
        /// <summary>
        /// Título da vaga
        /// <example> 09df2cb0-2622-4ae2-9b13-f6fb6986d09a <example>
        /// </summary>
        public string? Title { get; private set; }

        /// <summary>
        /// Categoria da vaga
        /// <example> Informática <example>
        /// </summary>
        public string? Category { get; private set; }

        /// <summary>
        /// Descrição da vaga
        /// <example> Desenvolvedor .NET <example>
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Endereço da vaga
        /// <example> Maputo, Moçambique <example>
        /// </summary>
        public string? Address { get; private set; }

        /// <summary>
        /// Gênero da vaga
        /// <example> MALE / FEMALE <example>
        /// </summary>
        public string? AudienceGender { get; private set; }

        /// <summary>
        /// Data de criação da vaga
        /// <example> 2022-02-09 <example>
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Data de expiração da vaga
        /// <example> 2022-03-09 <example>
        /// </summary>
        public DateTime ExpiresAt { get; private set; }

        /// <summary>
        /// Se va vaga é Tipo Freelance
        /// <example> true <example>
        /// </summary>
        public bool IsFreelance { get; private set; }

        /// <summary>
        /// Uma Lista dos benefícios oferecidos pela vaga
        /// <example> ["Vale refeição", "Seguro de saúde 75%"] <example>
        /// </summary>
        public IList<Advantage>? Advantages { get; private set; }

        /// <summary>
        /// Uma Lista dos requisitos obrigatórios para a vaga
        /// <example> ["2+ anos .NET Core", "4+ anos Desenvolvimento"] <example>
        /// </summary>
        public IList<Requirement>? Requirements { get; private set; }

        /// <summary>
        /// Proposta salarial da vaga
        /// <example> 40.000,00 <example>
        /// </summary>
        public float? SalaryOffer { get; private set; }

        // /// <summary>
        // /// Identificador do Proprietário da vaga
        // /// <example> 09df2cb0-2622-4ae2-9b13-f6fb6986d09a <example>
        // /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Proprietário da vaga
        /// <example> {"name": "Ladino", ...} <example>
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Identificador da Candidatura da vaga
        /// <example> 09df2cb0-2622-4ae2-9b13-f6fb6986d09a <example>
        /// </summary>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Retorna uma cópia da vaga com campos atualizados
        /// </summary>
        /// <param name="command">Vaga a ser salva no banco de dados</param>
        /// <returns>Cópia da vaga com atualização</returns>
        public Ad Copy(Ad value)
        {
            Ad newValue = value;

            newValue.Id = value.Id;
            newValue.Title = value.Title!;
            newValue.Category = value.Category!;
            newValue.Description = value.Description!;
            newValue.Address = value.Address!;
            newValue.AudienceGender = value.AudienceGender!;
            newValue.CreatedAt = value.CreatedAt;
            newValue.ExpiresAt = value.ExpiresAt;
            newValue.User = value.User!;
            newValue.IsFreelance = value.IsFreelance;
            newValue.Advantages = value.Advantages;
            newValue.Requirements = value.Requirements!;
            newValue.SalaryOffer = value.SalaryOffer;

            return newValue;
        }
    }
}
