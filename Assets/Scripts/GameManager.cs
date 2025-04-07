using UnityEngine;

public class GameManager : MonoBehaviour
{
    DoubleLinkedList<Character> characterList;

    private void Start()
    {

        characterList = new DoubleLinkedList<Character>();
        Character character1 = new Character("Jorge", 10);
        characterList.InsertAtStart(character1);
        //characterList.InsertAtStart(new Character("Rodrigo",20));
        //characterList.InsertAtStart(new Character("Francisco",15));

        print(characterList.Count);

        characterList.Print();
    }
}
