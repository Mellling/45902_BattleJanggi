using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{

    // 현재 위에 기물이 있는지 없는지?
    // 기물이 있다면
    // 기물의 레이어를 받아온다

    [SerializeField] LayerMask playerCheck;

    Piece whatPiece;

    bool onPiece;
    string whosPiece;   // tag = cho, han 초나라 한나라

    public Piece WhatPiece {  get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // 기물이 있다면
        {
            // 기물이 위에 있다는 bool을 true로 바꿔준다
            onPiece = true;
            // 내 위에 기물의 태그를 가져옴
            whosPiece = other.gameObject.tag;
            // 어떤 기물인지 받아오기
            whatPiece = other.GetComponent<Piece>();
        }
    }



    void ComparePiece()
    {
        //if ()
        //{
        //    // 초나라 기물임
        //}
        //else
        //{
        //    // 한나라 기물임
        //}


    }
}
