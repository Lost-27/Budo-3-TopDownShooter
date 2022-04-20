using System.Collections;
using System.Collections.Generic;
using TDS.Game.Core;
using UnityEditor;
using UnityEngine;

namespace TDS.Editor
{
    [CustomEditor(typeof(PatrolPath))]
    public class PatrolPathEditor : UnityEditor.Editor
    {
        readonly float size = 0.5f;

        private void OnSceneGUI()
        {
            PatrolPath patrolPath = target as PatrolPath;
            List<Transform> points = patrolPath.Points;

            if (points == null || points.Count == 0)
                return;

            Transform previousPoint = points[0];

            Handles.color = Color.blue;
            //Handles.DrawWireDisc(previousPoint.position, Vector3.forward, size);
            Handles.Label(previousPoint.position + new Vector3(0,1,0), $"{previousPoint.name}");
            Handles.SphereHandleCap(0, previousPoint.position, Quaternion.identity, size, EventType.Repaint);

            for (int i = 1; i < points.Count; i++)
            {
                Transform currentPoint = points[i];

                Handles.color = Color.blue;
                Handles.Label(currentPoint.position + new Vector3(0, 1, 0), $"{currentPoint.name}");
                Handles.SphereHandleCap(0, currentPoint.position, Quaternion.identity, size, EventType.Repaint);

                Handles.color = Color.red;
                Handles.DrawLine(previousPoint.position, currentPoint.position);
                previousPoint = currentPoint;
            }

            Handles.color = Color.red;
            Handles.DrawLine(points[points.Count - 1].position, points[0].position);
        }
    }
}

