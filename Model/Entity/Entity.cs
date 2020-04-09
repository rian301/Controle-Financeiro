//using FluentValidation;
//using FluentValidation.Results;

//namespace ControleFinanceiro.Model.Entity
//{
//    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
//    {

//        #region Properties
//        public ValidationResult ValidationResult { get; protected set; }
//        #endregion

//        #region Constructors
//        protected Entity()
//        {
//            ValidationResult = new ValidationResult();
//        }
//        #endregion

//        #region Métodos

//        public abstract bool IsValid();

//        #endregion


//    }
//}
