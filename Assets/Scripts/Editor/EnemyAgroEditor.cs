using TDS.Game.Enemies;
using UnityEditor;
using UnityEngine;

namespace TDS.Editor
{
    [CustomEditor(typeof(EnemyAgro))]
    public class EnemyAgroEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            EnemyAgro enemyAgro = (EnemyAgro)target;            

            Vector3 viewAngleA = enemyAgro.DirectionFromAngle(-enemyAgro.ViewAngle / 2, false);
            Vector3 viewAngleB = enemyAgro.DirectionFromAngle(enemyAgro.ViewAngle / 2, false);

            Handles.color = Color.blue;            
            Handles.DrawLine(enemyAgro.transform.position, enemyAgro.transform.position + viewAngleA * enemyAgro.CircleCollider.radius);
            Handles.color = Color.yellow;
            Handles.DrawLine(enemyAgro.transform.position, enemyAgro.transform.position + viewAngleB * enemyAgro.CircleCollider.radius);
        }
    }
}
