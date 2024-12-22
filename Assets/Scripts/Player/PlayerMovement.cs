using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //  玩家移动速度
    public float Speed = 6f;

    private Rigidbody rb;
    private Animator animator;

    //  游戏初始化时获取刚体组件
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    //  角色移动函数,通过刚体组件移动
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //  移动
        Move(h,v);

        //  角色旋转
        Turning();

        //  切换动画
        Animating(h,v);
    }

    void Move(float h,float v)
    {
        Vector3 movementV3 = new Vector3(h, 0, v);
        movementV3 = movementV3.normalized * Speed * Time.deltaTime;
        rb.MovePosition(transform.position + movementV3);
    }

    void Turning()
    {
        //  创建射线(在相机中鼠标位置处创建射线)
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //  获取图层
        int floorLayer = LayerMask.GetMask("Floor");
        //  返回的射线交点
        RaycastHit floorHit;
        //  射线检测
        bool isTouchFloor = Physics.Raycast(cameraRay, out floorHit, 100, floorLayer);
        if (isTouchFloor)
        {
            //  计算角色与交点之间的向量
            Vector3 v3 = floorHit.point - transform.position;

            //  计算需要旋转的角度
            Quaternion quaternion = Quaternion.LookRotation(v3);

            //  旋转
            rb.MoveRotation(quaternion);
        }

    }


    void Animating(float h, float v)
    {
        animator.SetBool("isWalking", h != 0 || v != 0);
    }

}
