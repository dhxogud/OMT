using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    // 카메라는 WASD, QE(카메라 y축 -+ 회전), 휠(Zoom-in, Zoom-out), 클릭 와 같은 Input event로 움직인다.
    // 또한 내가 선택한 케릭터가 적 케릭터를 '공격'할 때 타겟팅이 되었다는 것을 보여주기 위해 해당 타겟 유닛을 포커스 하러 움직인다.

    // 카메라 동작 개요 (클릭으로 인한)
    // 1. 마우스 클릭 감지 (이건 나중에 InputManager 클래스에서 옵저버 패턴으로 처리할 거임 여기서 안할듯)
    // 2. 카메라에서 Ray 발사 ... 이제 알았다 어떤 Input 값으로 인해 함수가 호출될때 마다 Ray는 일단 발사해서 정보를 얻어야 함.
    // 3. Raycast로 콜라이더 충돌 여부를 판단한다.

    // 4. 충돌이 일어난 위치로 이동한다. Slerp 방식으로 왜? y포지션도 고려해야 하므로
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField]
    GameObject _target = null;

    void LateUpdate() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100.0f))
            {
                _target = hit.collider.gameObject;

            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
           TurnAngle(-1);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            TurnAngle(1);
        }

        MoveToTarget();
    }

    void MoveToTarget() // 이거 1초 동안 움직이게 만들고 싶다. 이름도 바꿀거임 [타겟 선택] 이런 느낌으로
    {
        if (_target == null) 
            return;

        Vector3 dest = _target.transform.position + Vector3.up * 10.0f;

        transform.position = Vector3.Slerp(transform.position, dest, 0.8f) * Time.deltaTime;
        transform.LookAt(_target.transform);

    }

    // 이동과 회전을 동시에! 해야됨 구형 보간 이동 이후, 원래 바라보던 위치를 여전히 바라봐야됨
    // 대충 축의 거리는 8.0f 가 적당해 보이므로 이 값을 defalut로 두겠음 (기본 box object의 sclae 1일때를 기준)
    // 근데 생각해보니 내가 이제 맵의 노드들을 분리할때 그 노드의 위치벡터 기준으로 거리를 제야하니깐 지금은 정확한 수치를 마련 못하는 것도 당연하네?
    // 나중에 targetAxis 저 아래 10.0f 란 수치가 아니라. Vector3.Distance(transform.position, MapNode node...) 막 이런식으로 구해야겟듬
    void TurnAngle(int rotate_dir)
    {
        Vector3 targetAxis = transform.position + transform.forward * 10.0f; 
        // 여기서 10.0f는 변수로 저장되어야 하며, 나중에 zoom-in, zoom-out할 때도 쓰이는 수치임, min~max 사이에 값을 유지해야하는 수치임
        
        // Debug.Log((origin + transform.forward).magnitude);
        transform.position += transform.right * 10.0f * Time.deltaTime * rotate_dir;
        transform.LookAt(targetAxis);
        // Debug.Log((origin + transform.forward).magnitude);
    }
    
    void ZoomIn()
    {
        transform.position += transform.forward.normalized * Time.deltaTime; 
    }
    void ZoomOut()
    {
        transform.position -= transform.forward.normalized * Time.deltaTime; 
    }
    void Init()
    {
        _target = null;
    }
    
}
