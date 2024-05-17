using DeterministicLockstep;
using Unity.Entities;
using UnityEngine;

    public partial class InputGatherSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<MyCapsulesCustomInputs>();
        }

        protected override void OnUpdate()
        {
            var inputBuffer =  SystemAPI.GetSingletonBuffer<InputBufferData<MyCapsulesCustomInputs>>();
            Debug.Log("Buffer size: " + inputBuffer.Length);
            foreach (var inputs in SystemAPI.Query<RefRW<MyCapsulesCustomInputs>>())
            {
                int horizontalInput = 5;
                int verticalInput = 5;

                inputs.ValueRW.horizontalInput = horizontalInput;
                inputs.ValueRW.verticalInput = verticalInput;

                inputBuffer.Add(new InputBufferData<MyCapsulesCustomInputs>
                {
                    InternalInput = inputs.ValueRW
                });
            }
        }
    }
