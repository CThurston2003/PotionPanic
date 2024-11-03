//Name: Caleb Thurston
//Description: 
//Script to make a custom object of a MultiTag to deal with tagging an object to have multiple tags
//Language: C#
//Part of Project: Potion Panic

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTag : MonoBehaviour
{
    //--------------------Variables Section------------------------------
    

    //Creating the actual List to store the multiple tags
    [SerializeField]
    private List<string> tags = new List<string>();

    //Property to return if the object has a specific tag
    public bool HasTags(string tag){
        return tags.Contains(tag);
    }

    //Property for returning the whole list of tags on an object
    public IEnumerable<string> GetTags(){
        return tags;
    }
    
    //Property to rename a tag on an object
    public void Rename(int index, string newName){
        tags[index] = newName;
    }

    //Property to get a tag at a specific index
    public string GetAtIndex(int index){
        return tags[index];
    }
    
}
