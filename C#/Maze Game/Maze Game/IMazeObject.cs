using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Game
{
    internal interface IMazeObject
    {
        // attributes not supported
        // abstract prop
        public char Icon { get; }
        public bool IsSolid { get;}

        // abstract method
        // default impelemented method

    }
}

#region Interface


////////////////////////////////// before c#8
/// why we need interface ?
/// there is no multiple inheritance
/// struct do not inherit
/// can't lose multiple inheritance benefits

// inheritance benefits
// 1- code generization 
// 2- OCP (open for excetention -closed for modification principle)

////  interface :
/// like an abstract class , all members inside are abstract
/// interface is just code contract
/// just a prototype for methods & properties that will be imbelemented in classes & structs
/// (after c#8 ) these members can have body
/// can not define attributes in interface
/// a class can implement multiple interfaces
/// public class MyClass : IInterface1, IInterface2
/// notation : interface name should start with I
/// What can i write inside an interface :
/// 1- prototype for abstract properties
/// 2- prototype for abstract methodes
/// 3- method with body  : benefit : if you changed in the interface (added for ex) the old code do not break
/// default impelemented methods you don't have to impelemnt in class|struct
/// 4- can't write attributes
/// abstract = no body
/// interface can be multiple impelemented by classes or structs
/// not considered multiple inheritance
/// any class or struct that implements the interface should impelement all methods inside
/// before c#8 : i can't control access level inside the interface
/// after c#8 , i can
/// interface VS abstract class 
/// class can impelent multiple interfaces 
/// interface force you to impelemnt all abstract methods & prop
/// if u impelemnted an interface in abstract class you don't have to impelent all methods
/// impelementaion vs explicit impelementaion
/// when a struct impelemts interface => boxing
/// solid principles : it is recommended that you keep your interface minimal
/// has 2 or 1 method

/// interface benefits :
/// to acheive OCP 
/// 1- develop againest abstraction (use base type )
/// develop aginest interface
/// in order not to change base with each new type

/// You can write any code depends on a class that impelemnts 
/// an interface also before writing this class
/// as you are sure that this class will have this methods & prop

#endregion

