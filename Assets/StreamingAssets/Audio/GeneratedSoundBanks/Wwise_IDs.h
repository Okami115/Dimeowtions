/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_CINEMATICA = 1875134770U;
        static const AkUniqueID PLAY_ITEMS = 693379014U;
        static const AkUniqueID SET_PLAY_DEFEAT = 3169691074U;
        static const AkUniqueID SET_STATE_ALIVE = 1814951015U;
        static const AkUniqueID SET_STATE_MENU = 2302270969U;
        static const AkUniqueID SET_STATE_NOIR = 4109907276U;
        static const AkUniqueID SET_STATE_PAUSED = 2902924586U;
        static const AkUniqueID SET_STATE_SCIFI = 1446812956U;
        static const AkUniqueID SET_STATE_SYNTHWAVE = 21388497U;
        static const AkUniqueID SFX_GRAVITY_CHANGE = 1039583472U;
        static const AkUniqueID SFX_JUMP = 3695098761U;
        static const AkUniqueID SFX_LATERAL_MOVEMENT = 3187317502U;
        static const AkUniqueID SFX_OPEN_DOOR = 3913579892U;
        static const AkUniqueID SFX_PORTAL = 2266380775U;
        static const AkUniqueID START_BMG_MACHINE = 3941323550U;
        static const AkUniqueID STOP_BMG_MACHINE = 454668116U;
        static const AkUniqueID UI_CREDIT_BUTTON = 1314850096U;
        static const AkUniqueID UI_EXIT_BUTTON = 2170883505U;
        static const AkUniqueID UI_PLAY_BUTTON = 705989075U;
        static const AkUniqueID UI_POINTER = 4050451069U;
        static const AkUniqueID UI_SLICE_MENU = 1337377386U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace INGAME
        {
            static const AkUniqueID GROUP = 984691642U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PAUSED = 319258907U;
            } // namespace STATE
        } // namespace INGAME

        namespace MUSIC_STATES
        {
            static const AkUniqueID GROUP = 1690668539U;

            namespace STATE
            {
                static const AkUniqueID DEFEAT = 1593864692U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NOIR = 799227909U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SCIFI = 1794634511U;
                static const AkUniqueID SYNTHWAVE = 2932583730U;
            } // namespace STATE
        } // namespace MUSIC_STATES

    } // namespace STATES

    namespace SWITCHES
    {
        namespace DOORS
        {
            static const AkUniqueID GROUP = 2150196036U;

            namespace SWITCH
            {
                static const AkUniqueID NOIR = 799227909U;
                static const AkUniqueID SCIFI = 1794634511U;
                static const AkUniqueID SYNTHWAVE = 2932583730U;
            } // namespace SWITCH
        } // namespace DOORS

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PAUSED = 319258907U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID PORTAL_TRIGGER = 2843586610U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
