using UnityEngine;
using System.Collections;

public class AIStatePatrol : AIState
{
    public AIStatePatrol(EnemyController controller) : base(controller) { }


    public override void OnStateEnter()
    {
    }

    public override void OnStateExit(AIState newState)
    {
        base.OnStateExit(newState);
    }

    public override void StateUpdate()
    {
        bot.Move();
        if (bot.IfPlayerVisible())
        {
            OnStateExit(new AIStatePersuit(bot));
            return;
        }
    }

    public override void HandleTurnPointEnter()
    {
        OnStateExit(new AIStateIdle(bot));
    }
}
