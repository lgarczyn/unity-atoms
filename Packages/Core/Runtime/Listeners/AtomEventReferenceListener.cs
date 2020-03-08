using UnityEngine;
using UnityEngine.Events;

namespace UnityAtoms
{
    /// <summary>
    /// Generic base class for Listeners using Event Reference. Inherits from `AtomListener&lt;T, A, E, UER&gt;` and implements `IAtomListener&lt;T&gt;`.
    /// </summary>
    /// <typeparam name="T">The type that we are listening for.</typeparam>
    /// <typeparam name="A">Acion of type `T`.</typeparam>
    /// <typeparam name="E">Event of type `T`.</typeparam>
    /// <typeparam name="ER">Event Reference of type `T`.</typeparam>
    /// <typeparam name="UER">UnityEvent of type `T`.</typeparam>
    [EditorIcon("atom-icon-orange")]
    public abstract class AtomEventReferenceListener<T, A, E, ER, UER> : AtomBaseListener<T, A, E, UER>, IAtomListener<T>
        where A : AtomAction<T>
        where E : AtomEvent<T>
        where ER : IGetEvent, ISetEvent
        where UER : UnityEvent<T>
    {
        /// <summary>
        /// The Event we are listening for as a property.
        /// </summary>
        /// <value>The Event Reference of type `ER`.</value>
        public override E Event { get => _eventReference.GetEvent<E>(); set => _eventReference.SetEvent<E>(value); }

        /// <summary>
        /// The Event Reference that we are listening to.
        /// </summary>
        [SerializeField]
        private ER _eventReference = default(ER);
    }
}
